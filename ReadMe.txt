CIBC C# Technical Test

Duration: 2 hours
Internet access permitted: Yes/No

This test application contains 3 files (XML, CSV and pipe delimited) that contain fictional trades.  The application already loads the XML and CSV versions of these
files and parses them into Trade objects.  Each trade references a stock symbol, a price ticker is firing random price change events against each symbol.  

Points: Questions 2, 4 & 7 are worth 2 points each, the rest are worth 1 point.

Tasks

1. Change the code so that the pipe delimited file (trades.pip) is also loaded.	
2. Change the code so that the trade loaders are executed in parallel.
3. Identify and fix the potential resource leak with the PriceTicker class.
4. Change the tradeLoader class so that new loaders can be introduced at runtime without requiring recompilation of existing code (e.g. via a configuration file) 
5. Identify and remediate the race-condition in the PriceTicker class.
6. Implement the ValuationEngine so that it calculates the present value (PV) of a trade on each price tick and publishes the results
	- Each tick is for a symbol so you have to find each trade for that symbol
	- PV = (currentPrice - trade.Price) * quantity  (note: this is a basic calculation for the purpose of the test and not how you would typically value futures)
7. Write a UI in WPF or WinForms that displays the trade details and the realtime updates in PV.