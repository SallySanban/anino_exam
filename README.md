# Anino Games Exam - Johanna Eikou Teknomo
This game was created in partial fulfillment of the Software Engineer Intern application for Anino Games.

## About the System
### Unity version
2022.3.2f1

### System setup
This application can be downloaded from the ```builds/slotmachine.apk``` file on an Android device.

The following are the **main classes and controllers** in my application:
- **GameControl**: This class controls the objects of the game, including the coins, the total bets, the total wins, and the spinning of the reels.
- **Row**: This class controls how the spinning of the reels happen.
- **AddBet**: This class controls the adding of the total bet when the add sign is clicked.
- **SubtractBet**: This class controls the subtracting of the total bet when the minus sign is clicked.

The following are the **objects** in my application:
- Each UI element, including the background, the coins chip, the total bets chip, the total wins chip, and the spin button
- The reels (which are columns of possible options in the slot) which are masked to the slots
- The game control object
- The canvas which includes the texts for the coins, the total bets, and the total wins

#### Scalability and Flexibility
The application can run on a wide range of Android devices. It has been tested by two different Android phones and it showed consistency in the placements of the UI (despite that the y coordinates of the reels were hard-coded). I'm also open to testing this application in more types of phones in the future to further test its scalability.

#### Model-View-Controller
In my application, the use of MVC is mixed in the four classes I setup. Once the plus or minus buttons are clicked, the AddBet and SubtractBet classes are alerted and they change the total bet based on the number of lines (which is 3). Once the spin button is clicked, the GameControl class alerts the Row class and it is the Row class that implements the spinning of the reels. The GameControl class then changes the number of coins and the prize result accordingly. A diagram can be seen below.
![MVC](https://github.com/SallySanban/anino_exam/assets/38158416/7519abfb-3097-4b31-8af2-e609e98ba11a)

#### Possible improvements
- An iOS version could be developed to cater to a wider range of users. This can be done by installing the additional modules necessary for the iOS platform
- We could integrate the application with actual payment services through the use of their API.
- I was unable to include 20 lines as part of the win-condition of the game. Instead, the game's win condition is to find 3-4-5 matches in each row of the slot machine. A possible improvement in the game would be to implement the 20 lines and include wins from combinations from different rows.

## Game Screenshots
![Screenshot1](https://github.com/SallySanban/anino_exam/assets/38158416/d0f8c072-6623-4ee4-939f-37f4115f5887)
![Screenshot2](https://github.com/SallySanban/anino_exam/assets/38158416/b95fe44b-af0c-4a7d-9896-cd6a67d8c8a9)

**A video of the game being run can also be seen [here](https://github.com/SallySanban/anino_exam/assets/38158416/388f6df8-41d2-498a-87b6-2464da7dc363).**

## References
- All UI was originally made through Canva.
- Some code snippets and the algorithm idea for the slots spinning was taken from [this](https://www.youtube.com/watch?v=0U-vfNrRdIY&t=634s&pp=ygUgaG93IHRvIG1ha2UgYSBzbG90IG1hY2hpbmUgdW5pdHk%3D) YouTube video.
