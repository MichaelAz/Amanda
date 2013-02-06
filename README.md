Amanda
======

Amanda is a library that makes exposing an API via Nancy even easier

Easier Than Nancy?! No way!
--------------------------------------------
```C#

    public class AwesomeAPI : AmandaModule
    {
        public AwesomeAPI()
        {
            this.Exposes(BuisnesLogic.DoStuff)
            this.Start();
        }
    }

```

Yes way.

The Super-Duper-Happy-Path, redux
----------------------------------------------------
Amanda follows the SDHP creed extending the "fun and powerful" philosophy of Nancy with "easy as apple pie"

* "It just works" - any and all methods work with Amanda, out of the box. You give Amanda the bare minimum info about your method and the framework takes care of the rest.

* “Easily customisable” - Nancy is absurdly customisable with any and everything being replacebale. Amanda doesn't take that away or hide it but leverages it. Everything you know and love from Nancy still works like a charm with an added DSL for exposing methods through HTTP.

* “Low ceremony” & “Low friction” - take a look at the code snippet above. We're so low on ceremony and friction that we might just need to import some from WebAPI.

![BURN!!!](http://www.zgeek.com/wp-content/uploads/2012/09/kelso-burn.jpg)  

(Sorry Microsoft, we still ♥ you)

But Wait, There's More!
----------------------------------
But what's the syntax for method exposition?

How does Amanda do routing?

How do I customize my APIs?

And hey, what's with the name anyway?

All that and MORE in the project wiki. See ya there!

