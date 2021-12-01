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

v.1.8 - 23.11.2021:
- player have to spend money to free the truck by touch police car;
- fix: save created building after moving between scenes;
- save created objects after moving between scenes;
- change sumbut button to "space";
- player buy free places by giving money action;
- player can give money to police to free the truck;
- police return to office and start searching new target;
- add give money animation;
- bugfix: police car lose target when player enter the new scene and police is in waiting mode;
- police car moving to police station as a child object;
- truck moving to building (that create the truck) as a child object.

v.1.9 - 24.11.2021:
- can add managers in office;
- new arts for tables and managers;
- fix: increase money active zone;
- fix: hide all buildings when moving between scenes;
- bugfix: just player can enter free place location.

v.2.0 - 25.11.2021:
- can buy trucks inside office;
- truck contract show in players status panel;
- can add truck to world by putting contract inside selected building;
- add "lumber" building scene;
- one manager operates 3 trucks;
- managers generate costs;
- office generate costs;
- add game time (month, day, hour);
- change startpoint position when return to main scene;
- simple economics logic (updated Economics script).

v.2.1 - 27.11.2021:
- buildings has a cost;
- trucks generate income;
- get truck free has a cost;
- update textcontroller (remove debug text from script);

v.2.2 - 28.11.2021:
- remove trucks body, can move without collision;
- police choose target randomly;
- police define target by target id;
- fix: add unic names to created buildings and objects;
- add money text formatting;
- entering to all new buildings;
- truck can be connected to each building;
- delete old truckmoving model that determ movement by x,y position in the world. New model is object oriented.

v.2.3 - 29.11.2021:
- flying numbers (income/costs);
- flying truck (add truck from inventory);
- fix: save building objects when moving between scenes;
- fix: police pay in no money case.

v.2.4 - 01.12.2021:
- add building process loading;
- fix: loading process destroy on scene change;
- gameover scenario;
- police simple animation;

v.2.5 (to do):
- turn on/off police lights (renew animation);
- optimize StatusPanel script;
- fix: loading script before the main scene is loaded (game objects shown before new scene);
- economic balance;
- add simple audio;
- level design.
