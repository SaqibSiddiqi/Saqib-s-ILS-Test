# Saqib's ILS Test
 Saqub Hasan Siddiqi's test for infinite loop studios
# Scene Breakdown
MainMenu - Starting Play Menu
PlayArea - Where the game is Played
# GameObjects
PlayerObject - Player, moved with 2 different movement methods
Barriers - On hit, game is over
Enemy - Tracks the player when the player enters the boss area and attacks the player
# Areas
RunArea - Player moves forward, and could move left and right and snap back to the center on zero input. Player can also Jump
BossArea - Player moves forward, left and right to defeat the enemy
# GameOver Condition
1) If the player hits the barrier, the game is over
2) If the player is hit by the enemy's weapon
# Win Condtion
If the player can land on the enemy's head, the game is over and won
# Game Modes
There are 3 modes: - 
1) Easy Mode - Creates 5 rooms
2) Medium Mode - Creates 15 rooms
3) Hard Mode - Creates 30 rooms
                                                                -X-
