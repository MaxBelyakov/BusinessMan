# BusinessMan
Simple 2D Economic RPG in Unity

v.1.1 - 12.11.2021:
- assets packs (ground and player);
- player moving + animation.

v.1.2 - 14.11.2021:
- add animation moving left;
- camera following;
- new area - office;
- entering/exiting building;
- update moving as a physical body;
- add new titles;
- starting points.

v.1.3 - 15.11.2021:
- add factory object (without unit logic);
- add truck object (moving between 2 units);
- truck waiting for loading.

v.1.4 - 19.11.2021:
- add World Scenario script to respawn scenario game objects on start;
- save position and parametrs of game objects when moving between scenes;
- update waiting function.

v.1.5 - 20.11.2021:
- add new places for building to the world (wood, rocks, mountain);
- show text about each place when player enter;
- start building on target place by sibmit button.

v.1.6 - 21.11.2021:
- add police station which respawn police car;
- police car can wait randomly near the station and search for truck to catch;
- police car moving to the truck and follow him;
- add panel with money, trucks, managers, costs per month parametrs;
- add Economics script to collect simple economic logic there.

v.1.7 - 22.11.2021:
- police block the truck;
- fix: clear police station code (a lot of rubbish, no comments);
- add PoliceCar script that controll police car behavior;
- fix: make moving truck and police car script in common function;

v.1.8 (to do):
- buildings has a cost;
- trucks generate income;
- can add trucks inside office;
- can add managers in office, one manager operates 3 trucks;
- managers generate costs;
- office generate costs;
- player have to spend money to free the truck by touch police car;
- fix: save created building after moving between scenes;
- fix: add unic names to created buildings and objects;
- add building process loading;
- fix loading script before the main scene is loaded (game objects shown before new scene);
- simple economics logic;
- level design.
