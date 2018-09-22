# Aspire-2018-Generator

This program is designed to generate The Bic Pen's entry to the Aspire 2018 contest (https://osu.ppy.sh/community/contests/68). It creates a map that simulates Catch the Beat gameplay with a mouse by using a reversing slider with sliderticks as the notes. It generates the sliderticks and a storyboard to aprovide visual feedback to the player. 

The program has 2 modes: a file mode and a line-by-line mode. The line-by line mode is extremely tedious to use and is not recommended. It saves the output to 2 txt files on the user's desktop. The file mode reads a txt file as an input. This mode takes exactly 3 command-line arguments. The first is the location of the input file. The second is the path to the osu map file, while the third is the path to the stroyboard file.

The first line of the inupt file must be the initial x coordinate of the slider. The second line must be the start time of the slider, in milliseconds. After that, each line should have 3 numbers separated by spaces: the first should be an integer between -90 and 90 that represents the x coordinate of the next slidertick. The 2nd number is the approach rate in milliseconds, and the third number is the fruit colour (1 for coloured, 2 for white). Any line that should containt an object which cannot be split into 3 numbers that follow this format will be ignored by the program. Note that using this may desynchronize the storyboard from the map (it is untested).

Note that this program currently doesn't work very well for long songs, as the storyboard slowly desynchronizes from the map due to a division by 2 that then gets rounded to calculate the x coordinate of pointA.
         
Why do I use so many global variables and so few functions? Because I wanted to make this functional as quickly as possible.
