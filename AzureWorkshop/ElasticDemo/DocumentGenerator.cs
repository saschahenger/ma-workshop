using System;
using System.Collections.Generic;
using System.Text;

namespace AzureWorkshop.ElasticDemo
{
    class DocumentGenerator
    {
        // Quelle: http://www.asu.cas.cz/~bezdek/moje_stranky/die%20schoensten%20deutschen%20gedichte.htm

        public static IEnumerable<Dichter> GetDichters()
        {
            return new[]
            {
                new Dichter
                {
                    Vorname = "Friedrich",
                    Nachname = "Hölderlin",
                    Geburtsort = "Lauffen am Neckar",
                    Geburtstag = new DateTimeOffset(new DateTime(1770, 3, 20)),
                    Todesort = "Tübingen",
                    Todestag = new DateTimeOffset(new DateTime(1843, 6, 7))
                },
                new Dichter
                {
                    Vorname = "Matthias",
                    Nachname = "Claudius",
                    Geburtsort = "Reinfeld",
                    Geburtstag = new DateTimeOffset(new DateTime(1740, 8, 15)),
                    Todesort = "Hamburg",
                    Todestag = new DateTimeOffset(new DateTime(1815, 1, 21))
                },
                new Dichter
                {
                    Vorname = "Johann Wolfgang von",
                    Nachname = "Goethe",
                    Geburtsort = "Frankfurt am Main",
                    Geburtstag = new DateTimeOffset(new DateTime(1749, 8, 28)),
                    Todesort = "Weimar",
                    Todestag = new DateTimeOffset(new DateTime(1832, 3, 22))
                },
                new Dichter
                {
                    Vorname = "Friedrich",
                    Nachname = "Schiller",
                    Geburtsort = "Marbach in Württemberg",
                    Geburtstag = new DateTimeOffset(new DateTime(1759, 11, 10)),
                    Todesort = "Weimar",
                    Todestag = new DateTimeOffset(new DateTime(1805, 9, 5))
                }
            };
        }

        public static IEnumerable<Gedicht> GetGedichts()
        {
            return new[]
            {
                new Gedicht
                {
                    Autor = "Friedrich Hölderlin",
                    Titel = "Hälfte des Lebens",
                    Content = @"
                    Mit gelben Birnen hänget
                    Und voll mit wilden Rosen
                    Das Land in den See,
                    Ihr holden Schwäne
                    Und trunken von Küssen
                    Tunkt ihr das Haupt
                    Ins heilignüchterne Wasser.

                    Weh mir, wo nehm ich, wenn
                    Es Winter ist, die Blumen, und wo
                    Den Sonnenschein,
                    Und Schatten der Erde?
                    Die Mauern stehn
                    Sprachlos und kalt, im Winde
                    Klirren die Fahnen."
                },
                new Gedicht
                {
                    Autor = "Friedrich Hölderlin",
                    Titel = "Der gefesselte Strom",
                    Content = @"
                    Was schläfst und träumst du, Jüngling, gehüllt in dich,
                    Und säumst am kalten Ufer, Geduldiger,
                    Und achtest nicht des Ursprungs, du, des
                    Ozeans Sohn, des Titanenfreundes!

                    Die Liebesboten, welche der Vater schickt,
                    Kennst du die lebenatmenden Lüfte nicht?
                    Und trifft das Wort dich nicht, das hell von
                    Oben der wachende Gott dir sendet?

                    Schon tönt, schon tönt es ihm in der Brust, es quillt,
                    Wie, da er noch im Schoße der Felsen spielt',
                    Ihm auf, und nun gedenkt er seiner
                    Kraft, der Gewaltige, nun, nun eilt er,

                    Der Zauderer, er spottet der Fesseln nun,
                    Und nimmt und bricht und wirft die Zerbrochenen
                    Im Zorne, spielend, da und dort zum
                    Schallenden Ufer und an der Stimme

                    Des Göttersohns erwachen die Berge rings,
                    Es regen sich die Wälder, es hört die Kluft
                    Den Herold fern und schaudernd regt im
                    Busen der Erde sich Freude wieder.

                    Der Frühling kommt; es dämmert das neue Grün;
                    Er aber wandelt hin zu Unsterblichen;
                    Denn nirgend darf er bleiben, als wo
                    Ihn in die Arme der Vater aufnimmt."
                },
                new Gedicht
                {
                    Autor = "Matthias Claudius",
                    Titel = "Der Mensch",
                    Content = @"
                    Empfangen und genähret
                    Vom Weibe wunderbar
                    Kömmt er und sieht und höret
                    Und nimmt des Trugs nicht wahr,
                    Gelüstet und begehret
                    Und bringt sein Tränlein dar,
                    Verachtet und verehret,
                    Hat Freude und Gefahr,
                    Glaubt, zweifelt, wähnt und lehret,
                    Hält nichts und alles wahr,
                    Erbauet und zerstöret
                    Und quält sich immerdar,
                    Schläft, wachet, wächst und zehret
                    Trägt braun und graues Haar.
                    Und alles dieses währet,
                    Wenn's hoch kommt, achtzig Jahr.
                    Denn legt er sich zu seinen Vätern nieder,
                    Und er kömmt nimmer wieder."
                },
                new Gedicht
                {
                    Autor = "Johann Wolfgang von Goethe",
                    Titel = "Wandrers Nachtlied",
                    Content = @"
                    Über allen Gipfeln
                    Ist Ruh,
                    In allen Wipfeln
                    Spürest du
                    Kaum einen Hauch;
                    Die Vögelein schweigen im Walde.
                    Warte nur, balde
                    Ruhest du auch."
                },
                new Gedicht
                {
                    Autor = "Johann Wolfgang von Goethe",
                    Titel = "Ginkgo biloba",
                    Content = @"
                    Dieses Baums Blatt, der von Osten 
                    Meinem Garten anvertraut, 
                    Gibt geheimen Sinn zu kosten, 
                    Wie's den Wissenden erbaut.

                    Ist es ein lebendig Wesen, 
                    Das sich in sich selbst getrennt? 
                    Sind es zwei, die sich erlesen, 
                    Dasz man sie als Eines kennt?

                    Solche Frage zu erwidern, 
                    Fand ich wohl den rechten Sinn: 
                    Fühlst du nicht an meinen Liedern, 
                    Dasz ich Eins und doppelt bin?"
                },
                new Gedicht
                {
                    Autor = "Johann Wolfgang von Goethe",
                    Titel = "Erlkönig",
                    Content = @"
                    Wer reitet so spät durch Nacht und Wind?
                    Es ist der Vater mit seinem Kind;
                    Er hat den Knaben wohl in dem Arm,
                    Er faßt ihn sicher, er hält ihn warm.

                    Mein Sohn, was birgst du so bang dein Gesicht? -
                    Siehst Vater, du den Erlkönig nicht?
                    Den Erlenkönig mit Kron und Schweif? -
                    Mein Sohn, es ist ein Nebelstreif. -

                    »Du liebes Kind, komm, geh mit mir!
                    Gar schöne Spiele spiel ich mit dir;
                    Manch bunte Blumen sind an dem Strand,
                    Meine Mutter hat manch gülden Gewand.«

                    Mein Vater, mein Vater, und hörest du nicht,
                    Was Erlenkönig mir leise verspricht? -
                    Sei ruhig, bleibe ruhig, mein Kind;
                    In dürren Blättern säuselt der Wind. -

                    »Willst, feiner Knabe, du mit mir gehn?
                    Meine Töchter sollen dich warten schön;
                    Meine Töchter führen den nächtlichen Reihn
                    Und wiegen und tanzen und singen dich ein.«

                    Mein Vater, mein Vater, und siehst du nicht dort
                    Erlkönigs Töchter am düstern Ort? -
                    Mein Sohn, mein Sohn, ich seh es genau:
                    Es scheinen die alten Weiden so grau. -

                    »Ich liebe dich, mich reizt deine schöne Gestalt;
                    Und bist du nicht willig, so brauch ich Gewalt.«
                    Mein Vater, mein Vater, jetzt faßt er mich an!
                    Erlkönig hat mir ein Leids getan! -

                    Dem Vater grauset's, er reitet geschwind,
                    Er hält in den Armen das ächzende Kind,
                    Erreicht den Hof mit Mühe und Not;
                    In seinen Armen das Kind war tot."
                },
                new Gedicht
                {
                    Autor = "Friedrich Schiller",
                    Titel = "Das Mädchen aus der Fremde",
                    Content = @"
                      In einem Thal bei armen Hirten
                    Erschien mit jedem jungen Jahr,
                    Sobald die ersten Lerchen schwirrten,
                    Ein Mädchen, schön und wunderbar.

                        Sie war nicht in dem Thal geboren,
                    Man wußte nicht, woher sie kam;
                    Und schnell war ihre Spur verloren,
                    Sobald das Mädchen Abschied nahm.

                        Beseligend war ihre Nähe,
                    Und alle Herzen wurden weit;
                    Doch eine Würde, eine Höhe
                    Entfernte die Vertraulichkeit.

                        Sie brachte Blumen mit und Früchte,
                    Gereift auf einer andern Flur,
                    In einem andern Sonnenlichte,
                    In einer glücklichern Natur.

                        Und theilte Jedem eine Gabe,
                    Dem Früchte, Jenem Blumen aus;
                    Der Jüngling und der Greis am Stabe,
                    Ein jeder ging beschenkt nach Haus.

                        Willkommen waren alle Gäste;
                    Doch nahte sich ein liebend Paar,
                    Dem reichte sie der Gaben beste,
                    Der Blumen allerschönste dar."
                },
            };
        }
    }
}
