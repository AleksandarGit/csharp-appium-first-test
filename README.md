[![Build Status](https://travis-ci.org/seetest-io/csharp-appium-first-test.svg?branch=with_slack)](https://travis-ci.org/seetest-io/csharp-appium-first-test)

# This project contains four different tests:

### 1. Test for Android App
### 2. Test for iOS App
### 3. Test on Android Chrome
### 4. Test on iOS Safari

You can use these tests as templates for your own tests. Simply edit the capabilities and the test method to fit your needs.

# Running the tests

## Running the tests from your machine
You can clone the repository to your machine and open it in Visual Studio. The file *AssemblyInfo.cs* contains a line `[assembly: Parallelizable(ParallelScope.Fixtures)]`.
that is designed to allow you to run the tests in paralell
You can also run each test separately should you choose to.
The tests rely on an access key that allows you to send test requests to seetest.io cloud. In the code, the access key tries to look for an access key as
environment variable. If you haven't configured an access key as environment variable, you will have to specify it directly in the code.

## Running the tests using CI/CD services
We've included .yml configuration files in this project in order to allow you to run these tests in a CI/CD environment
For Jenkins, read our tutorial on how to set up the job.
See below for each service that we included:
### [Using seetest.io with Travis CI](https://docs.seetest.io/display/SEET/Using+seetest.io+with+Travis+CI)
### [Using seetest.io with Bitbucket](https://docs.seetest.io/display/SEET/Using+seetest.io+with+Bitbucket)
### [Using seetest.io with Jenkins](https://docs.seetest.io/display/SEET/Using+seetest.io+with+Jenkins)
### *circleci doesn't support .NET at the moment*


