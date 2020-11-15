using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BsButtonApi.Data.EntityModels;
using BsButtonApi.Data.Repositories;
using BsButtonApi.Data.ResultModels;
using BsButtonApi.Service.ViewModels;

namespace BsButtonApi.Service
{
    public class BsButtonService
    {
        private BsButtonCommandRepository CommandRepository { get; }
        private BsButtonQueryRepository QueryRepository { get; }

        public BsButtonService(BsButtonCommandRepository commandRepository, BsButtonQueryRepository queryRepository)
        {
            CommandRepository = commandRepository;
            QueryRepository = queryRepository;
        }


        public async Task<MethodResultValue<List<BsVerifyViewModel>>> GetBsVerifyViewModelList()
        {
            var result = new MethodResultValue<List<BsVerifyViewModel>>();
            var unconfirmedReportList = await QueryRepository.GetList<BsUnconfirmedReport>();
            var viewModelList = new List<BsVerifyViewModel>();
            foreach (var bsUnconfirmedReport in unconfirmedReportList)
            {
                var viewModel = MapToViewModel(bsUnconfirmedReport);
                viewModelList.Add(viewModel);

            }

            result.ReturnValue = viewModelList;
            return result;
        }

        private BsVerifyViewModel MapToViewModel(BsUnconfirmedReport bsUnconfirmedReport)
        {
            var viewModel = new BsVerifyViewModel
            {
                ReportReason = bsUnconfirmedReport.ReportReason,
                ReportGuid = bsUnconfirmedReport.ReportGuid,
                ReportText = bsUnconfirmedReport.ReportText,
                ReportId = bsUnconfirmedReport.UnconfirmedReportId,
                ReportedDateTime = bsUnconfirmedReport.ReportedDateTime,
                ReportedFrom = bsUnconfirmedReport.ReportedNameOfPoster,
                Verified = false
            };
            return viewModel;
        }


        public async Task<MethodResultValue<BsVerifyViewModel>> GetBsItem(int id)
        {
            var result = new MethodResultValue<BsVerifyViewModel>();
            var unconfirmedReportList = await QueryRepository.GetList<BsUnconfirmedReport>();
            var item = unconfirmedReportList.FirstOrDefault(rpt => rpt.UnconfirmedReportId == id);
            if (item == null) return result;
            var viewModel = MapToViewModel(item);
            result.ReturnValue = viewModel;
            return result;
        }

        public async Task<MethodResultValue<BsVerifyViewModel>> AddBsItem(BsCreateViewModel item)
        {
            var result = new MethodResultValue<BsVerifyViewModel>();
            var reasonCode = await QueryRepository.GetReasonCodeAsync(item.ReportReasonCode);
            if (reasonCode == null)
            {
                reasonCode = new BsReasonCode
                {
                    ReasonCode = BsButtonQueryRepository.OtherValue,
                    ReasonCodeGuid = Guid.NewGuid(),
                    ReasonCodeText = BsButtonQueryRepository.OtherValue
                };
                var addResult= await CommandRepository.Add<BsReasonCode>(reasonCode);
                var saveBsReasonCodeResult = await CommandRepository.SaveChangesAsync();
                reasonCode = addResult.ReturnValue;

            }
            var reason = new BsReason
            {
                ReasonCodeId = reasonCode.ReasonCodeId,
                ReasonGuid = Guid.NewGuid(),
                ReasonText = item.ReportReason
            };
            var reasonResult = await CommandRepository.Add(reason);
            var reasonSaveResult = await CommandRepository.SaveChangesAsync();

            var socialMediaSource = await QueryRepository.GetSocialMediaSource(item.ReportedFrom);
            if (socialMediaSource == null)
            {
                socialMediaSource = new BsSocialMediaSource()
                {
                    SourceCodeGuid = Guid.NewGuid(),
                    SourceCodeName = BsButtonQueryRepository.OtherValue
                };
                var addSocialResult = await CommandRepository.Add<BsSocialMediaSource>(socialMediaSource);
                var saveSocialRResult = await CommandRepository.SaveChangesAsync();
                socialMediaSource = addSocialResult.ReturnValue;
            }

            var source = new BsSource
                {SourceGuid = Guid.NewGuid(), SocialMediaSourceId = socialMediaSource.SourceCodeId, SourceUrl = item.ReportedFromUrl};
             var sourceResult = await CommandRepository.Add(source);
            var sourceSaveResult = await CommandRepository.SaveChangesAsync();

            var unconfirmedReport = new BsUnconfirmedReport
            {
                ReportGuid = Guid.NewGuid(),
                SourceId = source.SocialMediaSourceId,
                ReasonId = reason.ReasonCodeId,
                ReportReason = item.ReportReason,
                ReportedDateTime = item.ReportedDateTime,
                ReportText = item.ReportText,
                ReporterUserName = item.ReporterUserName,
                ReportedNameOfPoster = item.ReportedNameOfPoster
            };
            var addReportResult = await CommandRepository.Add(unconfirmedReport);

            var saveResult = await CommandRepository.SaveChangesAsync();
            var vm = new BsVerifyViewModel {ReportReason = addReportResult.ReturnValue.ReportReason};
            result.ReturnValue = vm;
            return result;
        }
    }
}