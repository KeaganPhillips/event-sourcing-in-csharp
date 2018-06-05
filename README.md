# Event Sourcing POC
Experimental project to try to implement an Event Sourcing framework using C#/dotNet core

## Key concepts
- An aggregate is a reduction of events: `aggregate = event[]`
- A command is a POCO/POCJO object
- Command handler process commands and emits events: `(command, aggregate) => event[]`
- You can apply a event to a aggregate: `(aggregate, event) => aggregate`


