# Galaxy-Assault
3d Rail shooter in space
based on the classic space shooter arcade game
a 3D remake of the classic arcade game
multiple levels added of different worlds
this repo only contains the scripts of the game
contains four scripts
  ->Collision controller- detect collissions with enemies or the environment
  ->if collision is detected, the game is over and restarts from the start
Music Player
  ->loads background music for different worlds
  ->this is a global script and works in all scenes
  ->music starts at the start of the level and stops if the game is over
Player controller
  ->This is the main controller script and controls the movement of the player
  ->player can control the ship in a constrained space
Scene loader
  ->loads the next worlds upon level completion
  ->resets the game to scene 1 on death
