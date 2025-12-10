/*Guess the word
Program a prototype for a game called Guessing the Word. The game works like this: 
● First you must enter a word. Then depending on the number of characters, 
it is due show unknown scripts on the screen by replacing the characters. 
● A user has to guess the word by entering a letter. 
○ If the letter is found in the word, it must be displayed on the screen again 
unknown scripts, except for the letters found by the user. 
○ If the user enters a letter that is not in the word, one must be deducted attempt. 
And you have a maximum of 3 attempts to guess the word. 
○ If the participant wins, a message must be displayed informing them that they 
guessed the word or if they lost report that you exhausted all three attempts. 
Example: 1- Enter word: programming 
2- Display on screen: - - - - - - - - - - - 
3- Enter a letter: a 
4- Display on screen: - - - - - a - a - - - - Attempts: 3 
5- Enter a letter: e 
6- Display on screen: - - - - - a - a - - - - Attempts: 2*/

#include <stdio.h>
#include <string.h>
#define SIZE 25
int main(){
char word[SIZE],guess[SIZE],repeated[SIZE],letter;
int i,j=0,characters,notPass=0,attempts=0,found,length,won=0,count=0;
printf("Enter the word: ");
gets(word);
characters=strlen(word);
for (i = 0; i < characters; i++)
{
    guess[i]='-';
    repeated[i]='-';
}
guess[characters]='\0';
repeated[characters]='\0';
puts(guess);
while (attempts!=3&&count!=characters)
{
    fflush(stdin);
    printf("enter a letter: ");
    fflush(stdin);
    scanf("%c",&letter);
    fflush(stdin);
for (i = 0; i < characters; i++)
{
    if (word[i]==letter)
    {   
        found=1;
        guess[i]=letter;
        for (j = 0; j < characters; j++)
        {
            if (guess[i]==repeated[j])
        {
            notPass=1;
        }
        }
        if (notPass==0)
        {
            count++;
            repeated[j]=letter;
        }
        notPass=0;  
    }
}
if(found==0)
{
    attempts++;
}
found=0;
puts(guess);
}
if (count==characters)
{
    printf("Winner");
}else{
    printf("All 3 attempts were exhausted");
}
    return(0);
}
