**SRP - Saitek Radio Panel for Flight Simulators**

SRP is a software for integrating the Saitek Radio Panel into flight simulators. It is compatible with the most popular flight simulators, including P3D version 4, and has advanced radio functionality, including frequency selection, transmission and reception modes for COM1, COM2, NAV1, NAV2 and ADF.

# Key features

-   Compatible with the most popular flight simulators, including P3D version 4.
    
-   Integration with the Saitek Radio Panel for a more realistic simulation experience.
    
-   Advanced radio functionality, including frequency selection, transmission and reception modes for COM1, COM2, NAV1, NAV2 and ADF.
    
-   Uses the FSUIPC client for communication between the software and the flight simulator.
    
-   Customizable by aircraft profile with well-structured and simple JSON files. Documentation is currently being prepared.
    
-   Supports any offset that FSUIPC can read and assign specific commands to. This gives it incredible potential!
    
-   Compiled for 64-bit processors.
    
-   Developed with Microsoft .NET CORE 6 library.
    
-   Compatible with Windows 10 (minimum version 10.0.19041.0).
    
-   High response speed on rotary encoders and buttons, as it does not use script code like LUA. Previously, I used LUA with LINDA, but could not achieve a high frequency response and thought it was due to my low-quality Rotary Encoder. But then I discovered that this code, being compiled X64 and using asynchronous reading of the HID device, runs very quickly.
    

  
  

##   
  

## TinyHidLibrary

TinyHidLibrary is a C# library for communicating with HID (Human Interface Device) devices specific to flight simulators, such as the Saitek Radio Panel. The library is largely based on the code of Mike O'Brien's HidLibrary, but many modifications have been made to adapt it to the specific needs of the Saitek Radio Panel.

The library was developed because the company that originally developed the device discontinued support, so it was decided to create a version of our own. The other options for controlling HID devices were not satisfactory, as they are more complex to configure and do not have the performance that was sought.

Improvements and modifications include the removal of delegates and the asynchronous BeginInvoke invocation method, which have been replaced by the TASK method. In addition, the way both read and write buffers are handled has been completely changed, as it was considered unnecessary to create a buffer every time the Read method is called. HidReport has also been removed. Read only returns StatusRead, the rest is in Buffers! Why encapsulate and re-encapsulate if it's in Buffers!

The TinyHidLibrary library only implements what is necessary for the Saitek Radio Panel. The Event Monitor has been removed because I do not consider it necessary and it could cause future problems. During normal operation, one would never intentionally want to disconnect/reconnect the device. It's not practical for this case. Error handling is another matter.

Finally, I would like to recognize and thank Mike O'Brien and his HidLibrary repository for his valuable base code. The link is below: [https://github.com/mikeobrien/HidLibrary](https://github.com/mikeobrien/HidLibrary)

  
  

  
  

# About the developer

My name is Esteban Maiutto. I live in Argentina. I am a .NET programmer with several years of experience and a fan of aviation in general, especially flight simulators. I hope that SRP will be of great help to those looking to improve their flight simulation experience. While this distribution is specific to radios, I have a version of the JSON customization files for use as a Boeing 737 PMDG series autopilot. It does not implement all functionalities logically, but it cleverly utilizes the displays, rotarys, and buttons, or at least I think so. As expected, anyone can incorporate reading parameters (called offsets) and commands for any plane. I have also developed my own more complete 737 Autopilot with ROF boards (4 integrated joystick type boards) and other simulator components (pedals, cessna-like throttle, landing gear, flaps, etc...)

## Contribution

Any contribution is welcome! If you encounter any issues or want to add new functionality, please feel free to make a pull request.

## License

SRP is distributed under the MIT license.