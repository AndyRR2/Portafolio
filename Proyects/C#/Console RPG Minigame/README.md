# RPG Console Game — C# Project

Single-player RPG console game where the player chooses a class and progresses through battles, leveling up, collecting items, and facing increasingly difficult enemies. The project focuses on gameplay logic, stats calculation, enemy scaling, and basic data persistence.

# Guide

To run the game, .NET 6 or a later version must be installed on your computer.

The game is executed from the console.

To launch the game, use the RunGame.exe shortcut.

If you start the game from the Visual Studio console using `dotnet run`:

The files Character.json, Constants.json, and Enemies.json must exist in the folder Project/Files in order to continue a saved game.

If these files do not exist, you will need to start a new game.

## Game Overview

- Choose between **Warrior**, **Mage**, or **Assassin**  
- Each class starts with **60 attribute points**, distributed differently  
- Character statistics are fully calculated from attributes and level  
- Win by defeating **all 10 enemies**  
- Lose when your HP reaches 0  
- You can **exit the game mid-run**, and your progress is saved  
- If you win or lose, the character data is deleted automatically

## Features

- **Randomized starting equipment**, generated through an external API (cosmetic only)  
- **10 procedurally generated enemies**, all starting at level 1  
- When an enemy is defeated:
  - All remaining enemies **increase their level**  
  - You gain EXP equal to the enemy’s HP  
  - You receive a **random equipment item** that replaces your current one  
- **Leveling system:**  
  - HP and MP fully restored  
  - +3 attribute points to distribute  
  - Exp requirements increase per level  
- **Combat menu** with 4 actions:
  1. **Basic Attack**  
  2. **Power Attack** (MP cost, stronger)  
  3. **Escape**  
  4. **Heal** (MP cost, restores a percentage of HP and MP)

## Formulas Used

**Health (HP):** `Strength×10 + Dexterity×5 + Intelligence×3 + Level×200`  
**Mana (MP):** `Intelligence×10 + Level×100`  
**Attack:** `Dexterity×10 + Strength×5 + Intelligence×3 + Level×10`  
**Power Attack:** `Attack + Intelligence×10 + Dexterity×5 + Strength`  
**Defense:** `Strength×10 + Dexterity×5 + Intelligence×3 + Level×10`  
**Heal Amount:** `30% HP + 30% MP`  

**MP Costs:**  
- Power Attack: **35% of max MP** (Mage pays 50% less)  
- Heal: **25% of max MP** (Mage pays 50% less)  

If you try to use Power or Heal with insufficient MP, you **lose the turn** and the enemy attacks.

## Gameplay Tips

- Use Power Attack or Heal at the right moment  
- Before leveling up, try to **spend most of your MP**, since it fully restores  
- With high-level enemies, **healing multiple times** can be stronger than using Power Attack  
- Mages have very efficient MP usage — take advantage of it  

## Project Goal

This project was created to practice:

- C# object-oriented programming  
- Game logic and balancing  
- Random generation mechanics  
- Data persistence  
- Combat system design


