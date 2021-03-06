#Task

##Functional programming and serverless computing

Grunntanke: Demonstrere funksjonell programmering, gjerne i ikke-funksjonelle språk, ved hjelp av fortrinnsvis enkle kodesnutter, og kjøre disse serverless, e.g. som functions, i skytjenester. 

Forslag til enkel problemstilling for å illustrere funksjonell programmering: 

Gitt en liste av fulle navn (fornavn+mellomnavn+etternavn) skal du skrive ut de tre oftest forekommende navnene, uavhengig av om navnet opptrer som fornavn, mellomnavn eller etternavn. Ved like mange forekomster skal ordene velges ut i alfabetisk rekkefølge. 

Eks: “Hans Hansen”, “Per Kristian Hansen”, “Kristian Kristiansen”, “Hans Kristian” 
skal gi Kristian, Hansen, Kristiansen

Først skrive en imperativ versjon, og så demonstrere hvordan koden kan skrives mer funksjonelt og hvilke fordeler/ulemper dette gir. 

Sette dette ut som en skytjeneste i feks Azure Function / Amazon Lambda / noe annet. 

Deretter håndtere en spesifikasjon endring, som krever en refactoring: 
Det viser seg at dataene kommer fra en crappy database og derfor må koden være uavhengig av ‘case’, videre skal dobbeltnavn (med bindestrek) tolkes som to navn. 
Altså: “PER-kristian” skal tolkes likt “per kristian”

The code is now in place for the meeting.
