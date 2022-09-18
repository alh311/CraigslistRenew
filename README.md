# CraigslistRenew [DEPRECATED]
This app is **deprecated**.  I've created a new, platform agnostic app in Node.js over here: https://github.com/alh311/CraigslistRenewJS
The node app runs much more quickly and doesn't need the constant package updates this console app needed.  Plus, it can run on Windows and Linux.  Win-win-win!

This is a console app for renewing your listings on Craigslist.  You can manually run the app whenever you want to renew your renewable listings.  This doesn't repost old, non-renewable listings.

## Usage Requirements
* Built for MacOS
	* The included binaries run on MacOS.  I'm assuming it will not run out-of-the box on Windows, so you may have to download the source code and re-publish it for use on Windows.

## Installation (Mac)
1. You have three options for installation:
	* Download the zip from the app folder.  This is the easiest.
	* Download the individual binaries from the app folder.
	* Clone the repo and build the binaries from source.
2. Ensure the three binaries (*CRSetup*, *CraigslistRenew*, *chromedriver*) are located in the same folder.
3. Ensure the three binaries have execution permissions.  I've found installing from zip retains the permissions while downloading the separate binaries does not.  YMMV.  To grant execution permissions see the *Execution Permissions* section below.

## How to Use (Mac)
1. Navigate to the app folder in the Terminal app.
	* If you don't know how to do this: https://techwiser.com/how-to-navigate-to-a-folder-in-terminal-mac/
2. Run the setup app using the command: `./CRSetup` and follow the instructions.  This only needs to be run once, prior to first use.  You can run this again if you need to update your email address, password, or user agent.  If you receive a "Permission denied" error, see the *Execution Permissions* section below.
3. Run CraigslistRenew using the command: `./CraigslistRenew`.  The app output will show you which listings have been renewed.  You can run this every couple days, when the 'renew' option becomes available on Craigslist.

## Execution Permissions
In Terminal you can use the following command to grant execution privileges to each binary inside the app folder:
```
chmod +x <appName>
```
For example:
```
chmod +x CRSetup
```
