import {testTool} from "./Tools";
import axios from "axios";
import OnClickData = chrome.contextMenus.OnClickData;

chrome.runtime.onInstalled.addListener(() => {
  // chrome.storage.sync.set({}, () => {
  // });
});

chrome.tabs.onUpdated.addListener(((tabId, changeInfo, tab) => {
  if (changeInfo.status === 'complete') {
    testTool();
  }
}));

console.log("registering context menu")
const bsReporter: (info: OnClickData, tab: chrome.tabs.Tab) => void = e => {
  axios.post("http://localhost:8080", {
    site: e.pageUrl,
    ...({information: e.selectionText})
  })
    .then(response => {

    })
    .catch(error => {
      console.warn("Unable to do stuff", error)
    })
};
chrome.contextMenus.create({
  title: 'Report Covid-19 B.S.',
  contexts: ['link', 'selection', "all"],
  onclick: bsReporter
}, function () {
})

chrome.contextMenus.create({
  title: 'Report site for Covid-19 B.S.',
  onclick: bsReporter
}, function () {
})
