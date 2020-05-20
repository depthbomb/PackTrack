# PackTrack

![Screenshot](https://i.imgur.com/vm8JCAB.png)

Program I quickly whipped up to track the delivery status of my new computer. The status is retrieved every 30 seconds. The window will flash until brought to the foreground whenever the progress has changed, indicating new activity.

Requires **.NET Framework 4.8+**

Usage
1. Run program
2. Enter UPS tracking ID
   * The ID will be saved to an ID.xml file alonside the exe so you won't need to run it again. Delete this file and restart PackTrack to enter a new ID.
3. Watch

Libraries used
* [RestSharp](http://restsharp.org/)
* [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview)
* My own common library