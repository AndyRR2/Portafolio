/*Target shooting 
a) In a Kermés the game of target shooting with darts is presented. 
The cost of a shot is $100. 
The prizes according to aim are: 
- The red circle with value 10 has a prize of $500. 
- Value circle 9 has a prize of $200. 
- Value circle 8 recovers $100. 
- Value circle 7 recovers $50. 
- The rest of the circles have no prize. 
Make a program that allows you to enter how many shots the player is going to make. 
Then, simulate them shots. Lastly, show how much money you spent, how much money you earned, and the player's final balance. 
Use the following functions: 
void loadShots(int *points, int shots); //Function to load shot scores. 
int calculateGain(int *points, int shots); //Function that calculates how much the player won. 
b) Modify the above program to work with an undetermined number of users. 
In addition to showing the results of each player, at the end of the game for all users, 
show the total amount paid for them, the total amount in prizes and the final balance. 
Choose the final mark that you consider appropriate. 
To do this, modify the calculateEarnings function with the following prototype: 
void calculateEarnings(int *points, int shots, int *totalPayments, int *totalPrizes) where: 
- totalPayments: accumulates the payment made by the players 
- totalPrizes: accumulate the number of prizes won by players*/

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void chargeShots(int *points,int shots);
void calculeProfit(int *points, int shots, int*totalPay,int *totalPriz);
int main(){
    srand(time(NULL));
    int points=0,initial,shots,final;
    int *profit,spent,user=0,totalPay=0,totalPriz=0;
    printf("New User(1=yes, 0=no): ");
    scanf("%d",&user);

    while (user!=0)
    {
    printf("Enter the number of shots you are going to make: ");
    scanf("%d",&shots);
    initial=shots*100;
    points=initial;
    chargeShots(&points,shots);
    calculeProfit(&points,shots,&totalPay,&totalPriz);
    if (points<=0)
    {
        printf("Profit: 0\n");
    }else
    {
        printf("Profit: %d\n",points);
    }
    
    if (points<=0)
    {
        printf("Spent: %d\n",points*-1);
    }else
    {
        printf("Spent: 0\n");
    }
    final=initial+points;
    printf("Final balance: %d\n",final);
    printf("New User(1=yes, 0=no)");
    scanf("%d",&user);
    }
    printf("Total payments made: %d\n",totalPay);
    if (totalPriz<0)
    {
        printf("Total accumulated prizes: 0");
    }else
    {
        printf("Total accumulated prizes: %d\n",totalPriz);

    }
    return(0);
}
void chargeShots(int *points,int shots){
    int *array,i;
    array=(int*)malloc(shots*sizeof(int));
    for (i = 0; i < shots; i++)
    {
    *array=rand()%10+1;
    *points=(*points)-100;
    switch (*array)
    {
    case 10 : *points=(*points)+500; break;
    case 9 : *points=(*points)+200; break;
    case 8 : *points=(*points)+100; break;
    case 7 : *points=(*points)+50; break; 
    }
    array++;
    }
}

void calculeProfit(int *points, int shots, int*totalPay,int *totalPriz){
int *profit;
*points=(*points)-shots*100;
*totalPay=(*totalPay)+shots*100;
*totalPriz=(*totalPriz)+*points;

}
