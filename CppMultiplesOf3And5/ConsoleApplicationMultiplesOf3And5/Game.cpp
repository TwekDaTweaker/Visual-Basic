#include "pch.h"
#include <iostream>
#include <stdlib.h>
#include <string>
#include <ctime>

#define endl "\n"


using namespace std;

int deck[2][13] = { {2,3,4,5,6,7,8,9,10,10,10,10,11},
					{4,4,4,4,4,4,4,4, 4, 4, 4, 4, 4} };

const string deckFace[13] = { "2","3","4","5","6","7","8","9","10","Jack","Queen","King","Ace" };

int cardDeal( bool isVisible )
{
	int card;

	do
	{
		card = (rand() % 13) + 1;

	} while ( deck[1][card] <= 0 );

	deck[1][card] -= 1;

	if ( isVisible )
	{
		cout << "You took: " << deckFace[card] << endl << endl;
	}
	else
	{
		cout << "The dealer took: " << deckFace[card] << endl << endl;
	}

	return deck[0][card];
}

int main()
{
	srand( time( nullptr ) );

	int cardsPlayer[15] = { 0 };
	int pTotal = 0;

	int cardsDealer[15] = { 0 };
	int dTotal = 0;

	bool lost = false;

	cardsPlayer[0] = cardDeal( true );
	cardsDealer[0] = cardDeal( false );
	cardsPlayer[1] = cardDeal( true );
	cardsDealer[1] = cardDeal( false );

	// player turn
	for ( int turn = 2; turn <= 10; turn++ )
	{
		// total
		pTotal = 0;
		for ( int i = 0; i < 15; i++ )
		{
			pTotal += cardsPlayer[i];
		}
		
		cout << "Your total is: " << pTotal << endl << endl;

		// win conditions
		if ( pTotal == 21 )
		{
			cout << "You win!" << endl;
			lost = true;
			break;
		}
		else if ( pTotal > 21 )
		{
			bool ace = false;

			for ( int i = 0; i < 15; i++ )
			{
				if ( cardsPlayer[i] == 11 )
				{
					cardsPlayer[i] = 1;
					pTotal -= 10;
					cout << "But you have an ace, so your new total is: " << pTotal << endl << endl;
					ace = true;
					break;
				}
			}

			if ( !ace )
			{
				cout << "You lost!" << endl;
				lost = true;
				break;
			}
			else
			{
			}
		}

		// interaction
		cout << "Would you like to hit? (y/n) ";

		string ans;
		cin >> ans;
		cout << endl;

		if ( ans == "y" )
		{
			cardsPlayer[turn] = cardDeal( true );
		}
		else
		{
			break;
		}
	}

	// dealer turn
	if ( !lost )
	{
		for ( int turn = 0; turn < 15; turn++ )
		{
			// total
			for ( int i = 0; i < 15; i++ )
			{
				dTotal += cardsDealer[i];
			}

			cout << "The dealer's total is: " << dTotal << endl << endl;

			// win conditions
			if ( dTotal == 21 )
			{
				cout << "The dealer won!" << endl;
				lost = true;
				break;
			}
			else if ( dTotal > 21 )
			{
				bool ace = false;

				for ( int i = 0; i < 15; i++ )
				{
					if ( cardsDealer[i] == 11 )
					{
						cardsDealer[i] = 1;
						dTotal -= 10;
						cout << "But he has an ace, so his total is: " << dTotal << endl << endl;
						ace = true;
						break;
					}
				}

				if ( !ace )
				{
					break;
				}
				else
				{
				}
			}

			if ( dTotal < 18 )
			{
				cardsDealer[turn] = cardDeal( false );
			}
			else
			{
				break;
			}
		}
	}

	// outcome
	if ( !lost )
	{
		if ( pTotal > dTotal )
		{
			cout << "You win!" << endl;
		}
		else if ( pTotal == dTotal )
		{
			cout << "Draw" << endl;
		}
		else if ( dTotal > 21 )
		{
			cout << "You win!" << endl;
		}
		else
		{
			cout << "You lost!" << endl;
		}
	}

}