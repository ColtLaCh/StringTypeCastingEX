void CreateEnemiesFromOrder()
{   
	//The format for creating the order list is "10L/23R/4R/7L/2R/E#" where "/" is the end of the number/direction and "E#" is the end of the string

	for (int i = 0; i < enemies.Length; i++)
	{
		if (eTimer[i] <= 0)
		{
			if (enemyOrder[i].IndexOf("#") > 1)
			{
				//Spawn Enemy and add to the amount
				Instantiate(enemies[i], new Vector3(300 * eSpawnDir, -75, 0), Quaternion.identity);
				eAmountCur[i]++;
				enemyAmount[i]++;
				eAmountSum++;

				//Calculate direction
				int endStringPosition = enemyOrder[i].IndexOf("/");
				string LorR = enemyOrder[i].Substring(endStringPosition-1, 1);
				eSpawnDir = LorR == "R" ? 1 : -1;
				Debug.Log(eSpawnDir + LorR);

				//Calculate next spawn time
				string orderTime = enemyOrder[i].Substring(0, endStringPosition-1);
				eTimer[i] = float.Parse(orderTime);
				int startStringPosition = enemyOrder[i].IndexOf("/") + 1;
				endStringPosition = enemyOrder[i].IndexOf("#") + 1;
				string newOrder = enemyOrder[i].Substring(startStringPosition, endStringPosition-startStringPosition);
				enemyOrder[i] = newOrder;

			}
		}
		else 
		{
			eTimer[i] -= Time.deltaTime;
		}
	}     
}