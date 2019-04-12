
[![Build Status](https://gabriel1786.visualstudio.com/MvvmQuiz/_apis/build/status/Gabriel1786.MvvmQuiz?branchName=master)](https://gabriel1786.visualstudio.com/MvvmQuiz/_build/latest?definitionId=2&branchName=master)

iOS - 
[![Build status](https://build.appcenter.ms/v0.1/apps/4fb62c9d-1b27-47f4-a9b5-fe9d6f23d61b/branches/appcenter/badge)](https://appcenter.ms)

Android - 
[![Build status](https://build.appcenter.ms/v0.1/apps/b191498c-6292-4ef4-bb72-093b62a4c248/branches/appcenter/badge)](https://appcenter.ms)

UWP - 
[![Build status](https://build.appcenter.ms/v0.1/apps/d515e30d-7f53-414f-a964-fa323bf5fdb4/branches/appcenter/badge)](https://appcenter.ms)

macOS - WIP

# MvvmQuiz
A fictitious simple Quiz App that utilizes the MvvmCross framework to build in Android, iOS, macOS e UWP.




## How to build
This project will not build correctly right after cloning. This is because I am utilizing Mobile.BuildTools to inject my 'secrets' into my source code during build. With this I am able to keep sensitive information out of my source control.
In order to fix this and make it buildable, you must add a new file into each project (iOS, Android, macOS and UWP) at the root level called 'secrets.json'. 

Populate each file with this json:
```
{
  "FirebaseApiKey": "",
  "FacebookAppId": "",
  "GoogleClientId": "",
  "GoogleCustomScheme": "",
  "FacebookCustomScheme": "",
  "AppCenterSecret": ""
}
```

Since you are not providing the real values, OAuth login will not function.

