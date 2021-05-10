
# Ariba Ariba!

## Solving the challenge
Havefun.txt was obviously base64 formatted, and a quick test exposed the PK zip header, which leaved the first step to be solved like:
```sh
cat havefun.txt | base64 --decode -i > decoded.zip
```
ZIP-file proved to be password protected, and trying the obvious #TE404, SPNChallenge * < the VOB pass >* etc. did not work. Tried to use fcrackzip with a 136MB rockyou leaked password list, and letting the computer crack away with "John the ripper" as well - all to no avail. A hint from Roberto solved the problem as the pass was a little deviation from the VOB pass we normally use - only difference being a slight change in the casing of two letters.

In the enclosed "delivery.pdf" I have interpreted the assignment as the arrows meaning only in the direction of the arrow is transport possible. I have also understood the assignment as listing all possible routes between two points given the rules outlined, so that a person that can attribute cost to the time and has knowledge to prioritize cost vs. time given the available options.

## Solution prerequisites

.NET 5 SDK installed - get it here:

https://dotnet.microsoft.com/download

## Running the application:

```sh
dotnet run --project SPN.Challenge2 
```

### Output

    
```sh
A H E D F I B Cost: 112 Time: 157
A H E D F G B Cost: 180 Time: 151
A E D F I B Cost: 115 Time: 147
A E D F G B Cost: 183 Time: 141
A C B Cost: 32 Time: 2

Suggested route is : A C B since it has lowest time and cost
```

## Testing

```sh
dotnet test
```