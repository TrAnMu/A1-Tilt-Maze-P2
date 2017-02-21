Travis Mudd
Programming Assignment 1, Part 2

A. Required Elements
- Use either the arrow keys or "WASD" to tilt the board
- Maneuver the ball collect 2 pick-ups and then into the black circle to win
- Hit 'q' to quit
- Hit 'r' to restart
- I allow a maximum tilt of ~10 degrees in any direction

B. Additional Elements
- Particles flow vertically with respect to the world and not the particle filter. 
- Lights do not dim after reset (Lighting is baked once).
- Walls lock at perfect 90 degree angles after rotation rather than over or undershooting it.

C. Known Issues
- The tilt limit occasionally allows the x and z to exceed the limit, causing controls to lock up. I can usually wrestle back control with some fiddling.
- A consequence of the correct rotation about y is that the walls can begin to phase through the platform slightly after some platform movement. The game is still perfectly playable and I prefer this concession to get the walls to rotate properly. (If you don't rotate the map, you can see that the walls stay fully above the surface.)

D. External Resources
- None.