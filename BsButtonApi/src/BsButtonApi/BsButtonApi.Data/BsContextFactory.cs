using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace BsButtonApi.Data
{
  public   class BsContextFactory
    {
        public BsContext CreateBsContext(string[] args])
        {
            return new BsContext("");
        }
    }
}
