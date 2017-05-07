# Vive-Live
An HTC Vive via OSC to Max for Live and Ableton Live Musical Instrument

Created by Ryan Walker and Oliver Macro during a creative session in Dunedin, New Zealand

HTC Vive controllers are used in combination with [insert max for live osc plugin name] to take incoming Open Sound Control (OSC) signals from the controllers positional information, and is then routed into two audio Oscillators.

## Demo

[![IMAGE ALT TEXT](http://img.youtube.com/vi/RhmCDwmDXCI/0.jpg)](http://www.youtube.com/watch?v=RhmCDwmDXCI "Vive Live Demo 01 ")

https://www.youtube.com/watch?v=RhmCDwmDXCI

## Running It
  
You will need a computer with Unity3D, Ableton Live, Max for Live, and  Ethno Tekh's '[Tekh Map](http://www.ethnotekh.com/software/tekh-map/)' Max for Live devices installed. Open the repository in Unity. Look at the Live Sessions folder for the associated Ableton Live project. 

Currently the IP address of the sending computer is hard coded to localhost (127.0.0.1). This means it will not by default send OSC signals to another computer. This can be changed in OSCHandler.cs and edit the address in the Init function.
```csharp
public void Init()  {
        //Initialize OSC clients (transmitters)
        //Example:		
        CreateClient("Live", IPAddress.Parse("192.168.178.169"), 8000);
}
```

## Technical Details

Currently 2 vive controllers are supported, and they send the following data via OSC:
* /vc1/x floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
* /vc1/y floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
* /vc1/z floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
* /vc1/trigger 0.0f for unclicked, 1.0f for clicked;
* /vc1/gripped 0.0f for ungripped, 1.0f for gripped;

* /vc2/x floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
* /vc2/y floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
* /vc2/z floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
* /vc2/trigger 0.0f for unclicked, 1.0f for clicked;
* /vc2/gripped 0.0f for ungrippped, 1.0f for gripped;

Ableton Live Project contains two tracks, each containing a simple mono synth patch. Ethno Tekh's '[Tekh Map](http://www.ethnotekh.com/software/tekh-map/)' Max for Live devices handle routing of the HTC Vive controllers OSC data to each synth. 

* Vertical Axis - Note/Pitch
* Horizontal Axis - Voice Panning
* Depth Axis - Filter Resonance
* Trigger Button - Note on
* Grip Pads - Note off

The patches function as rudimentary theremin-esque sound generators.
