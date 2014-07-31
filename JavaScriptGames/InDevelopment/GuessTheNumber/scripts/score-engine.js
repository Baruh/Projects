var scoreEngine = (function() {
	'use strict';
	var bestPlayers = sortPlayersByScore(getDateFromLocalStorage()),
		SCORES_LIST_SIZE = 10;

	// Visible functions
	function getBestPlayers() {
		return bestPlayers;
	}

	function addScore(player, score) {
		var currentScore;

		if (bestPlayers.length < SCORES_LIST_SIZE || isInScoreList(player)) {
			/*
			* Adds the current score only if the previous score of this player
			* is worse or the player is without score at all. We use -1 because
			* we want the default value to be smaller than every score
			* including 0. If the player name is not a key, the local storage 
			* will return null.
			*/
			currentScore = parseInt(localStorage.getItem(player), 10) || -1;
			if (currentScore < score) {
				localStorage.setItem(player, score);
			}

			bestPlayers = sortPlayersByScore(getDateFromLocalStorage());

		} else {
			addOnlyGoodScore(player, score);
		}		
	}

	// Hidden helper methods 
	function getDateFromLocalStorage() {
		var len = localStorage.length,
			playersTopScores = [],
			player,
			score,
			i;

		for (i = 0; i < len; i += 1) {

			player = localStorage.key(i);
			score = parseInt(localStorage.getItem(player), 10);

			playersTopScores.push({
				'player': player,
				'score': score
			});
		}

		return playersTopScores;
	}
	
	function addOnlyGoodScore(player, score) {
		var i = 0,
			lowestScoreKey,
			obj;

		while (i < SCORES_LIST_SIZE && bestPlayers[i].score > score) i += 1;

		if (i < SCORES_LIST_SIZE) {
			lowestScoreKey = bestPlayers[SCORES_LIST_SIZE - 1].player;
			localStorage.removeItem(lowestScoreKey);

			localStorage.setItem(player, score);
			bestPlayers = sortPlayersByScore(getDateFromLocalStorage());
		}
	}

	function isInScoreList(player) {
		var len = bestPlayers.length,
			i;

		for (i = 0; i < len; i += 1) {
			if (bestPlayers[i].player === player) return true;				
		}

		return false;
	}

	function sortPlayersByScore(players) {
		players.sort(function(a, b) {
			// descending sort
			return b['score'] - a['score'];
		});

		return players;
	}

	return {
		getBestPlayers: getBestPlayers,
		addScore: addScore
	};
}());