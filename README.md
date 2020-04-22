# CS 426 | Shadow Ninjas

“Shadow Ninjas” is a single-player stealth-based puzzle platformer where the player must avoid getting caught in the light while attempting to traverse towards the goal.

Click [here](https://docs.google.com/document/d/1GfetEonuZh1vZPsSSmyIRLoUsPLANioezbgUWlbjrvE/edit?usp=sharing) to view our design document.

| Authors |
| ----------- |
| Kevin Kowalski |
| Marcin Perkowski |
| Jonathan Vega |

---

## Assignment 9

### Ready-to-play Download:
* GitHub Release: https://github.com/kkowal28/cs426_ShadowNinjas/releases/tag/v0.9

#### Demo:
  We've improved the game with some more menus such as better controls screen, opening cutscene, end-of-level screen, and ending credits. For this demo, navigating the first level should be more clear on where to go; the solution to the first level is the same as the previous demos but this time there is more than one level to complete! The next level requires the player to platform on the mountain near spawn and push down the crate to use as a stepping stone to get on top of the stacked crates also at spawn. Then, the player must jump onto the ledge in front of the crates, sneak past the patrol, and jump to the next pillar that is straight across. From there, jump to the next pillar, push down the crate, and push it towards the rock blocking the gate. After getting past the gate, avoid the firing range of archers and make it safely across to the next set of patrols. But becareful, there's lots of patrols and it's hard to keep track of where they're going!

#### Shaders:
  * AutoTiling (*Kevin*)
  * Lighting (*Marcin*)
  * Wireframe (*Jonathan*)
  
#### Feedback Improvements:
  * Improved existing controls screen to be more helpful (*Kevin*)
  * Improved movement controls (*Kevin*) 
  
#### Forms of Writing:
  * Opening cutscene (*Kevin*)
  * End credits (*Jonathan*)
  
#### Other:
  * Saving/Loading game data (*Marcin*)
  * End-of-level screen (*Marcin*)
  * Score, shuriken, and lives counters on screen (*Marcin*)
  * Extend the game with more levels (*Everyone*)

---

## Assignment 8

### Ready-to-play Download:
* GitHub Release: https://github.com/kkowal28/cs426_ShadowNinjas/releases/tag/v0.8

#### Demo:
  We've extended and prettied our game a bit more. This time, the first level starts the player in a safe zone in the forest. From there, the player is lead down to the castle that the ninja must navigate similarily to the last assignment's level. Knocking out torches is much better now with a lock-on feature. The second level is a work in progress but will feature archers shooting in a firing range that the ninja must avoid while also trying to collect 2 keys that will open the door to the fortress to take the player to the final level!
  
#### Audio:
  * **Background**
    * Main menu music (*Kevin*)
    * Ambient wind during levels (*Marcin*)
    * Crickets chirping (*Jonathan*)
  * **Sound Effects**
    * Shuriken thrown (*Kevin*)
    * Gong when beating a level (*Kevin*)
    * Crates being pushed (*Marcin*)
    * Torches burning (*Marcin*)
    * Enemy alerted (*Jonathan*)
    * Falling down sound (*Jonathan*)

#### UI:
  * Main menu (*Kevin*)
  * Pause menu (*Kevin*)
  * Lock-on indicator (*Kevin*)
  * Tip text (*Marcin*)
  * Tip text theme adjustment (*Kevin*)
  * Better win/lose message (*Marcin*)
  * Improved lighting to better see player character (*Marcin*)
  * Start phrase (*Jonathan*)

---

## Assignment 7

### Ready-to-play Download:
* GitHub Release: https://github.com/kkowal28/cs426_ShadowNinjas/releases/tag/v0.7
* Google Drive mirror: https://drive.google.com/file/d/1nkBw8exgEvCeIwK_hdSFpuGgEhPbKTyx/view?usp=sharing

#### Demo:
  Get to goal by avoiding enemy AI path, extinguish torches in your path by shooting them, push crates to jump higher, and platform your way to the goal of first level. Second level (not finished) has archers lined up in firing range that you must avoid when they shoot.
  
#### Puzzles:
  * Avoid stationary and moving light sources
  * Push crates to navigate higher
  * Avoid enemy bows (on second leve, lose trigger not implemented here)

#### Textures:
  * stone wall (*Kevin*)
  * dirt and grass models (*Jonathan*)
  * wood crates (*Marcin*)
  
#### Audio:
  * Extinguishing torches (*Jonathan*)
  * Enemy footsteps (*Kevin*)
  * Enemy shooting arrow from bow (*Marcin*)
  
#### AI:
  * First level has 2 AI, each patrolling a path (*Kevin*)
    * AI on grass moves in waypoint loop
    * AI on castle walls backtracks when reaching end of path
  * Second level has archers firing at random intervals (*Marcin*)
  
#### Physics:
  * Particle fire physics on torches (*Kevin*) and flaming arrow (*Marcin*)
  * Arrows being shot includes flight physics (*Marcin*)

#### Lights:
  * Moving AI holds a hand torch for a moving light source (*Kevin*)
  * Arrows are flaming and light up path (*Marcin*)
  
#### Animations:
  * **Enemy AI**
    * shoot bow animation (*Kevin*)
    * idle lookout animation (*Kevin*)
    * walk with torch animation (*Kevin*)
  * **Ninja**
    * sneak walk animation (*Marcin*)
    * jump animation (*Jonathan*)
    * idle animation (*Kevin*)
    * throw ninja star animation (*Kevin*)
    
#### Rationale:
  Enemies are from a medieval-like nation and so they built a castle out of stones. To prepare for the invasion, they scattered their supply crates throughout the castle grounds and are guarding them with nightly patrols. However, the enemy helmets are difficult to see through and so they can only see brightly lit areas usually near torches. As they patrol, they make sounds depending on the surface material they are walking on.
  
  Enemies are also practicing their archery skills and so they've lined up to create a practicing firing range, igniting their arrows so that they can see where it lands as they practice. 

---
  
## Assignment 6

* Prototype of game
