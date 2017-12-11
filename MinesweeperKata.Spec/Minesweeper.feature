Feature: Minesweeper
	In order to not die
	As a minesweeper player
	I want to see a grid showing where the mines are

Scenario: Show no mines
	Given I have entered a 1 x 1 grid into the MineVisualiser
	And I have entered also entered a grid that looks like "."
	When I execute generate
	Then the result should be "0" on the screen