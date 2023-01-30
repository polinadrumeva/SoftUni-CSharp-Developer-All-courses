SELECT SUM(g.DepositAmount - h.DepositAmount) AS SumDifference
	FROM [WizzardDeposits] h
	JOIN [WizzardDeposits] g ON g.Id + 1 = h.Id