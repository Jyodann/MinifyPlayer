# Minify 🎵🎶

# Deprecation Notice

Hi! Thanks for checking Minify out, unfortunately, due to OS-related Windowing Issues, I have moved development to a successor, Bittify.

[Check it out here!](https://github.com/Jyodann/Bittify)

Online services for Minify have currently been ceased, and the code here is meant for archival purposes. 

I hope you understand, and thank you for your continued support!

## About 🐳
![image](https://user-images.githubusercontent.com/48559311/206890530-882078c0-647a-46c8-8331-b1b0445148fb.png)


Minify is a Miniplayer built for Windows which shows the current song you have playing on [Spotify](https://www.spotify.com/us/download/windows/). 

Useful for people who want to see what songs are currently playing without constantly tabbing back to the main application. It also be used as a Window Source on OBS for Twitch streamers to easily show what they are listening to.

[Download it here!](https://github.com/JordynWinnie/MinifyPlayer/releases)

<br>

## Features 🐣 

- Live syncing with the current song playing on your Spotify account, regardless of the device that is playing it

![image](https://user-images.githubusercontent.com/48559311/206890914-09261e2a-970f-4f1f-94d2-9b99631d5319.png)

- Allows you to resume, pause, skip, go previous on your music without going back to the main application. (Premium Spotify Only)

![image](https://user-images.githubusercontent.com/48559311/206890926-92412be7-df67-4b96-a680-8aa3aa5d26c3.png)

- Has a "Pin to top" feature that allows it to stay on top of every other window 

![image](https://user-images.githubusercontent.com/48559311/206890981-13611f68-bb38-4781-a5c1-52f3b8505e5b.png)

<br>

## Install ⚒️

1. Unzip the file
2. Double Click on `Minify.exe`
3. Allow the Application to run if there is any security pop-up
4. Click `Login to Spotify` and paste the code in.
5. The application should start displaying what is playing when you play a song on Spotify on any device!

<br>

## Notes 📝

- This software is still under Beta, meaning there might be bugs, glitches or errors when using it. If you encounter any, please feel free to email me here: jordynwinnie@gmail.com
- You may also email any feedback you have, it is much appreciated. 💖
- For those who hate email, you can also contact me on Discord: Jyudan#8272

<br>

# Technical Details (WIP)

## Application Infrastructure 🚠

Built with:
- [Unity 2021.3.15f1](https://unity.com/releases/editor/whats-new/2021.3.15)
- .NET 7 Minimal Web API (Backend)

Backend runs on:
- AWS Lambda Functions
- AWS API Gateway

<br> 

## Setting up Development Environment 🖥️

### Requirements:
- [Unity 2021.3.15f1](https://unity.com/releases/editor/whats-new/2021.3.15)
- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

### Instructions: 

1. Clone project, and open with Unity Hub.
2. You will need your own client ID and client secret from [Spotify Developer Dashboard](https://developer.spotify.com/dashboard/login)
3. Add the following environment variables on your machine:
- `minify_client_id` with your own Client ID
- `minify_client_secret` with your own Client Secret
4. In your Developer Project, set `https://localhost:7000/callback` as one of the redirect URLs 
5. From the root folder of the project, open the `Backend` folder in a terminal and run the `dotnet run` command to start the server. 
6. In Unity, open the `MainScene` scene from the `Scenes` folder. You can start the application and click on `Login to Spotify`
7. If set up correctly, the backend should give you a code after you have logged in to Spotify. 
