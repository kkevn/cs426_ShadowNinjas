# CS 426 | Shadow Ninjas

“Shadow Ninjas” is a single-player stealth-based puzzle platformer where the player must avoid getting caught in the light while attempting to traverse towards the goal.

Click [here](https://docs.google.com/document/d/1GfetEonuZh1vZPsSSmyIRLoUsPLANioezbgUWlbjrvE/edit?usp=sharing) to view our design document.

| Authors |
| ----------- |
| Kevin Kowalski |
| Marcin Perkowski |
| Jonathan Vega |

## Assignment 7

Link: https://drive.google.com/file/d/1nkBw8exgEvCeIwK_hdSFpuGgEhPbKTyx/view?usp=sharing

Demo:
  Get to goal by avoiding enemy AI path, extinguish torches in your path by shooting them, push crates to jump higher, and platform your way to the goal of first level. Second level (not finished) has archers lined up in firing range that you must avoid when they shoot.
  
Puzzle:
  * Avoid stationary and moving light sources
  * Push crates to navigate higher
  * Avoid enemy bows (lose trigger not implemented)

Textures:
  * stone wall
  * dirt and grass models
  * wood crates
  
Audio:
  * Extinguishing torches
  * Enemy footsteps
  * Enemy shooting arrow from bow
  
AI:
  * First level has 2 AI, each patrolling a path
    * AI on grass moves in waypoint loop
    * AI on castle walls backtracks when reaching end of path
  * Second level has archers firing at random intervals
  
Physics:
  * Particle fire physics on torches and flaming arrow
  * Arrows being shot includes flight physics

Lights:
  * Moving AI holds a hand torch for a moving light source
  * Arrows are flaming and light up path
  
Animation:
  * Enemy AI
    * shoot bow animation
    * idle lookout animation
    * walk with torch animation
  * Ninja
    * sneak walk animation
    * idle animation
    * throw ninja star animation
  

## Assignment 6

* Prototype of game
