import {testTool} from "./Tools";

chrome.runtime.onInstalled.addListener(() => {
  // chrome.storage.sync.set({}, () => {
  // });
});

chrome.tabs.onUpdated.addListener(((tabId, changeInfo, tab) => {
  if (changeInfo.status === 'complete') {
    testTool();
  }
}));
