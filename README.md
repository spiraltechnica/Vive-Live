# Vive-Live
An HTC Vive via OSC to Max for Live and Ableton Live Musical Instrument

Created by Ryan Walker and Oliver Macro during a creative session in Dunedin, New Zealand

HTC Vive controllers are used in combination with [insert max for live osc plugin name] to take incoming Open Sound Control (OSC) signals from the controllers positional information, and is then routed into various audio Oscilators.

Currently 2 vive controllers are supported, and they send the following data via OSC:

/vc1/x floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
/vc1/y floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
/vc1/z floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
/vc1/trigger 0.0f for unclicked, 1.0f for clicked;

/vc2/x floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
/vc2/y floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
/vc2/z floating point number, no bounds as yet. Relative to the middle position in the SteamVR tracked environment.
/vc2/trigger 0.0f for unclicked, 1.0f for clicked;


