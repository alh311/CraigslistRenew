# CraigslistRenew
This is a console app for renewing your listings on Craigslist.  You can manually run the app whenever you want to renew your renewable listings.  This doesn't repost old, non-renewable listings.

## Usage Requirements
* Built for MacOS
	* The included binaries run on MacOS.  I'm assuming it will not run out-of-the box on Windows, so you may have to download the source code and re-publish it for Windows use.

## How to Use (Mac)
1. Either download the pre-built apps or build them from source.  *CRSetup*, *CraigslistRenew*, and *chromedriver* should all be in the same folder.
2. Navigate to the app folder in the Terminal app.
	* If you don't know how to do this: https://techwiser.com/how-to-navigate-to-a-folder-in-terminal-mac/
3. Run the setup app using the command: `./CRSetup` and follow the instructions.  This only needs to be run once, prior to first use.
4. Run CraigslistRenew using the command: `./CraigslistRenew`.  The app output will show you which listings have been renewed.  You can run this every couple days, when the 'renew' option becomes available on Craigslist.

#### Note:
If you received a "Permission denied" error when trying to run the apps, you will need to give each of the three apps (*CRSetup*, *CraigslistRenew*, *chromedriver*) execution privileges.  In Terminal you can use the following command to grant execution privileges inside the app folder:
```
chmod +x <appName>
```
For example:
```
chmod +x CRSetup
```