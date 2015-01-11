# EvilCat
Evil Cat is a 3D first person simulator where you pretend to be a cat. Your mission is to cause monetary damage without your owner detecting you while doing so. There is a minimap that shows you the position of your owner and his field of view.

The idea for a cat game came to be when I was at my girlfriend’s place over Fall break. She has two cats that are constantly making trouble by knocking things over, chewing on wires, clawing at furniture, and vomiting on the carpet. This led me to create a game where you are a cat set to destroy household objects without being caught by your owner.
I quickly made a model of the cat and a terrain (tiled with kitchen tiles) and set up keyboard controls to move, run and jump. I then imported the Smooth Follow script that’s part of the Camera Scripts in the Unity Standard Assets to have the camera follow the cat. Then, I created and added a room layout with objects like jars and cereal boxes laid out on top of desks and shelves. I added a person that would patrol the area and a small minimap on the bottom left of the screen with a view of the room from above. I implemented a scoring system and had my friends playtest the game.
Through playtesting, I learned a couple of important points. Nearly all the playtesters wanted a better way to tell if the owner could detect the cat or not. They suggested a field of view on the minimap that would help signal to the player when he was safe or not. They suggested that it would be more fun to see the objects crashing. I noticed that even though there was a running mechanism available to the players, most of the playtesters didn’t use it.
Following the initial round of playtesting, I worked on a second prototype where I disabled the running mechanism. I also constructed a mechanism that would allow the camera to switch to any falling objects before switching back to the cat. The hardest part was to create the triangular field of view on the minimap that would be able to detect if the cat was in view of the user. I had to create a custom mesh and mesh collider, however there were many problems with the collision detection between the cat and the mesh for which I had to find roundabout solutions. In the second prototype, I introduced sounds and a more colorful UI into the game to give a better play experience.
After a second round of platesting, I received a lot of positive feedback about the gameplay experience but the biggest complaint was about the jump mechanic since a lot of them had difficulty completing jumps between platforms. I realized this was due to the camera angle that made it difficult for user to detect the edges of the platforms; players would move off the edge and then try to jump. To counter this problem in the final prototype, I introduced the ability to change the camera angle through mouse scrolling to allow players to choose the angle they are most comfortable with.