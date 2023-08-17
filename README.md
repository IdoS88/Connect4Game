
# Demos:
https://github.com/IdoS88/Connect4Game/assets/109031500/bcdb9b08-b490-4357-a5f9-8a3883000e7b


https://github.com/IdoS88/Connect4Game/assets/109031500/af5ddf6d-2fe5-42ac-80ff-84085d33612b

# Connect 4 Game Project - .NET WinForms and ASP.NET Razor Pages

Welcome to the Connect 4 Game Project repository! This project was developed as part of an academic .NET programming course in collaboration with my partner, Ayal Cohen. The aim of this project was to create a comprehensive application that includes a Connect 4 game using .NET WinForms and a user-friendly website built with ASP.NET Razor Pages.

## Connect 4 Game: Overview

Connect 4 is a classic two-player connection game where players take turns dropping colored discs into a vertically suspended grid. The objective is to connect four of one's own discs of the same color consecutively in a horizontal, vertical, or diagonal line to win.

### How to Win:
- Connect four of your discs horizontally, vertically, or diagonally.
- Strategically block your opponent from forming their own four-disc connection.

## Project Workflow and Implementation

### 1. Register on the Website
To begin, users must register on the website. Registration data is securely stored in the server-side database. After successful registration, users are directed to their player details page. Here, they can manage their account, view player statistics, and access game analytics obtained using Entity Framework Core queries.

### 2. Playing the Game
The game is played on the client side using .NET WinForms. To initiate a new game, click on "New Game" and provide your name and unique player ID. Once confirmed, players can engage in multiple rounds of Connect 4. Game results are stored both locally and on the server-side database.

### 3. Technical Implementations
- **Database:** Microsoft SQL Server is used for data management. Two databases are maintained – one for server-side game records and player information, and another for local game records.
- **Communication:** An API controller ensures seamless interaction between the client-side game and the server-side database, enabling accurate tracking of game progress and player details.
- **Parallel Operation:** The WinForms game has to runs parallel to the website!, creating a synchronized user experience.

## How to Use the Project

1. **Website Interaction:**
    - Register on the website to create a player account.
    - Access your player details page for account management and game statistics.

2. **Playing the Game:**
    - Launch the WinForms application alongside the website.
    - Click on "New Game" and enter your name and unique player ID.
    - Play Connect 4 against another player computer (made through API for calculating computer moves).
    - Game progress is recorded on both the server and locally.

Feel free to explore the code, study the implementations, and contribute enhancements. This project demonstrates the integration of WinForms and ASP.NET Razor Pages in an engaging manner.

Thank you for exploring our Connect 4 Game Project. Enjoy playing the game as much as we enjoyed creating it! 🎮🕹️

For inquiries or feedback, please contact [[(https://www.linkedin.com/in/ido-shamir-7a278022b/)](https://www.linkedin.com/in/ido-shamir-7a278022b/)https://www.linkedin.com/in/ido-shamir-7a278022b/].
