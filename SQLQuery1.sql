

with cteDice as(
	select die=a 
	from (values ('1'), ('2'), ('3'), ('4'), ('5'), ('6')) AS X(a)
)

, cteSixDice as (
	select dice = concat(d1.die,d2.die,d3.die,d4.die,d5.die,d6.die)
	from cteDice d1
	cross join cteDice d2
	cross join cteDice d3
	cross join cteDice d4
	cross join cteDice d5
	cross join cteDice d6

	where 1=1
	and d2.die >= d1.die
	and d3.die >= d2.die
	and d4.die >= d3.die
	and d5.die >= d4.die
	and d6.die >= d5.die
)

select distinct x.DiceCount, x.Dice, points = 0
from (
	select dice, DiceCount = 6 from cteSixDice
	union select substring(dice,1,5), 5 from cteSixDice
	union select substring(dice,1,4), 4 from cteSixDice 
	union select substring(dice,1,3), 3 from cteSixDice 
	union select substring(dice,1,2), 2 from cteSixDice 
	union select substring(dice,1,1), 1 from cteSixDice 
) x


order by 1 desc, 2 asc