# PatientMonitor
A sample app utilizing Kinvey Live Service to implement simple patient status monitoring.

This is a Xamarin.iOS sample app to illustrate how to use Kinvey Live Service to implement a simple patient status monitoring app with user-to-user feed communication. 

## Concepts illustrated in this sample
* Logging in a user
* Posting of feed communication messages by one user which can be followed by another user.

## Prerequisites
* iOS 10 or later
* Xamarin Studio 6.3 or later
* Kinvey-Xamarin-iOS SDK v3.0.6 or later.

## Usage
There are 2 users enabled for this app: Greg and Bob.  By following the steps below, you will be able to see simple status messages from one device logged in as Bob appear on another device logged in as Greg, utilizing Kinvey Live Service.
* Launch the app on two devices/simulators.
  * On one device/simulator, log in as Greg (username: "Greg", password: "greg").
  * On the other device, log in as Bob (username: "Bob", password: "bob").
* Once logged in as Greg, you will see a static display which will show status messages from Bob.
* Once logged in as Bob, status messages in the form of an integer will be randomly generated and posted at 1 second intervals.
  * When Bob starts to `post` status messages, these messages will also appear on Greg's device, because Greg is configured to `follow` Bob.

__Note:__ Once Bob is logged out, the device will stop posting status messages.  At that time, updates will stop appearing on Greg's device.

## License

Copyright (c) 2017 Kinvey, Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
