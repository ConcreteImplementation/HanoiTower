### Tower of Hanoi

There are faster, simpler and overall better algorithms out there for solving this classical puzzle. The following is yet another way discovered by observing an almost rythmical pattern in the **from** pins.

Once solved, we would normally verify if the number of moves is optimal ($2^n-1$). In this method, we let the rules go until we reach the optimal number of moves. At that point, the tower is be solved.

##### The To Pin
The **to** pin can be deduced from the **from** pin and the **move number**. It follows a 3 moves cycle. On any of these 3 states, only two pins are possible to move a disk to. Here is an example :

When the number of disks is even and the move number % 3 is 0, then the to pin index will either be 1 or 2. If the from pin is 1, then the to pin will be 2; if the from pin is 2, then the to pin will be 1. This can be reduced by XORing the from pin with 3.

There is one such XORing rule for every 3 moves, depending on wether the number of disk is even or odd (a total of 6 rules).

Now that we know how to deduce the to pin, we need to deduce the from pin.

##### The From Pin
The **from** pin can be deduced from the **move number**. It follows a 6 moves cycle. Every odd move is constant. The even numbers follow this rule:

For any even move on the 6 moves cycle (2, 4 and 6), the from pin can only have one of two choices: choice A or choice B.

Start with the divisor 4. If the move number (the actual move number) divided by the divisor has no remainder, multiply the divisor by 4. Continue until there is a remainder.

When there is a remainder, the remainder will either be half the divisor or not. If it is, IsDivider is true, and choice A is taken, otherwise, choice B is taken. Here is an example:

Lets say we are at move number 8 with an even number of disks. Move number 8 is the 2nd move of the 6 move cycle (8 % 6 == 2). In this situation, the rule states that choice A is 0 and choice B is 2.

We first divide 8 by 4. The resulting remainder is 0. We then multiply the divisor by 4, so we divide 8 by 16. The remainder is 8, which is half 16. The choice will be A (take disk from pin 0).

This result can also be achieve by verifying whether the move number in binary format has an even number of trailling zeros. This method has been suggested by a user of MathExchange and named the TwoAdicAlgorithm. The tower switch to the TwoAddictAlgorithm after 23 disks, where it showed to be faster.
