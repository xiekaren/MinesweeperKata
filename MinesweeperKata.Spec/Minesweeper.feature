Feature: Minesweeper
	In order to not die
	As a minesweeper player
	I want to see a field showing where the mines are

Scenario: No mines on a 1x1 field
	Given I enter a 1 x 1 field "."
	When I use the mine visualiser
	Then I should see "0"

Scenario: 1 mine on a 1x1 field
	Given I enter a 1 x 1 field "*"
	When I use the mine visualiser
	Then I should see "*"