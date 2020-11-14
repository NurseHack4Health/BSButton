// content script that runs on each tab
import {testTool} from "./Tools";

chrome.runtime.onMessage.addListener((msg, sender, sendResponse) => {
  testTool();
});

