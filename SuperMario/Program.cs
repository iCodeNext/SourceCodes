/*
You are working on a video game where the player has to go through a level without falling into any obstacles.

The player starts at position zero and can move in three ways:
- L (left)  => one position to the left
- R (right) => one position to the right 
- J (jump)  => move two positions, in the direction of the previous move

The player starts at position 0 and the exit will always be at position 10.

The instructions never lead the player outside the level boundaries, and the first move is always right.

Write a function that given the instructions and the positions of the obstacles, returns True if the instructions lead to the exit position, and False otherwise.

For example:

Obstacles 1: [4,6]  

--------------------------------------------------------
  ->                X         X                   Exit
--------------------------------------------------------
0    1    2    3    4    5    6    7    8    9    10  


Instructions 1: "RRRJJRRR" -> True.

                  JUMP      JUMP
-----------------/-----\---/-----\----------------------
  ->   ->   ->      X         X      ->   ->   -> Exit
--------------------------------------------------------
0    1    2    3    4    5    6    7    8    9    10  


Instructions 2: "RRRLJ" -> False, it would just lead back to the start.

Instructions 3: "RRRJJRRRL" -> True, extra instructions can be ignored.

Instructions 4: "RRRLRJJRRR" -> True, the player is allowed to move back and forth.

Instructions 5: "RRRRRRRRRR" -> False, due to falling into an obstacle.

Instructions 6: "RRJJJJ" -> False, as the jump would land on an obstacle.

Instructions 7: "RLRRRJJRRLLJJJLRRRJJRRR" -> True, even after many instructions, exit is reached.

Instructions 8: "RRRJJRLJJJRRR" -> False, as directions of jumps must be observed.

Instructions 9: "R" -> False, as the exit position isn't reached.

Instructions 10: "RJJJJR" -> True, as it gets to the exit after avoiding the obstacles.

Instructions 11: "RJJRRRRR" -> False, as it hits an obstacle.

Obstacles 2: [9,4,2], Instructions 12: "RJJRRRJ" -> True, as it gets to the exit after avoiding the obstacles.

Obstacles 3: [], Instructions 9: -> False

All test cases: 

obstacles_1 = [4,6]
obstacles_2 = [9,4,2]
obstacles_3 = []

level(obstacles_1, instructions_1) # True
level(obstacles_1, instructions_2) # False
level(obstacles_1, instructions_3) # True
level(obstacles_1, instructions_4) # True
level(obstacles_1, instructions_5) # False
level(obstacles_1, instructions_6) # False
level(obstacles_1, instructions_7) # True
level(obstacles_1, instructions_8) # False
level(obstacles_1, instructions_9) # False
level(obstacles_1, instructions_10) # True
level(obstacles_2, instructions_11) # False
level(obstacles_2, instructions_12) # True
level(obstacles_3, instructions_9)  # False

Complexity variables:

N - number of instructions.
*/