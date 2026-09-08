using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data;

public class DataInitializer
{
    private readonly BlixtHackDbContext _context;

    public DataInitializer(BlixtHackDbContext context)
    {
        _context = context;
    }

    public void Migrate()
    {
        _context.Database.Migrate();
    }

    public void Seed()
    {
        var categories = new List<Category>
        {
            new()
            {
                Title = "Programmering"
            },
            new()
            {
                Title = "Teknik"
            },
            new()
            {
                Title = "Gaming"
            },
            new()
            {
                Title = "Film & TV"
            },
            new()
            {
                Title = "Övrigt"
            }
        };
        var topics = new List<Topic>
        {
            new()
            {
                TopicCategory = categories[1],
                Title = "Bara jag som gillar smaken på bilbatterin?",
                BodyText =
                    "smaka på ett bilbatteri igår änna, å de va la rätt syrligt eller?? typ som sura nappar fast mä lite mer el i jäveln. fatter ente varför fölk ente snackar mer om detta asså",
                Alias = "Hannes99",
                CreatedAt = DateTime.Now,
            },
            new()
            {
                TopicCategory = categories[4],
                Title = "abc, har ni också svårt med alfapetet?",
                BodyText =
                    "hej ja vet inte om de här e rätt forum men ja har typ svårt me alfabetet o har typ alltid haft de asså ja kan bokstäver om ja ser dom men när ja ska säja dom i ordnig så blir de fel typ a b c d e f g sen vet ja inte om de e h eller j eller va som kommer o sen blandar ja ihop typ j k l m n o ibland glömer ja nån helt\n\nhar försökt me alfabet sången men ja tappar bort mej där me o de e lite pinsamt för ja e vuxen liksom men de fastnar typ inte i huvet nån som har samma eller vet hur man lär sej de enklare för ja har försökt flera gånger men de blir bara fel endå",
                Alias = "Beter87",
                CreatedAt = DateTime.Now,
            },
            new()
            {
                TopicCategory = categories[1],
                Title = "hur jag byggde om min robot damsugare till en trovärdig kompanion",
                BodyText =
                    "hej tänkte dela med mig av ett litet projekt jag hållt på med senaste månaderna. började egentligen bara med att jag ville att min robot damsugare skulle sluta köra in i samma stol 14 gånger varje kväll men de eskalerade lite.\n\nförst monterade jag en liten högtalare på den så den kunde säga \"ursäkta\" när den körde in i mig. tyckte de gjorde den mer artig.\n\nsen kopplade jag den till en raspberry pi och la till några röst kommandon. nu heter han Kenneth och kommer när jag ropar på honom ungefär 40% av gångerna. resterande 60% kör han mot köket eller fastnar under soffan.\n\nhar även monterat två googly eyes fram och en liten arm gjord av lego som kan hålla en ölburk. problemet är att han inte kan öppna den så de är mer symboliskt stöd.\n\nKenneth följer numera med mig mellan rummen och jag har programmerat honom att säga \"de löser sig mannen\" om jag svär mer än tre gånger inom 30 sekunder.\n\nenda riktiga problemet just nu är att han ibland startar själv runt 03:00 och kör fram till sovrumsdörren där han bara står helt stilla.\n\njag har inte programmerat den funktionen.\n\nnågon som vet varför?",
                Alias = "CircuitpöjkenLOL",
                CreatedAt = DateTime.Now,
            },
            new()
            {
                TopicCategory = categories[4],
                Title = "Hur min kompis blev min kusin AMA",
                BodyText = "Precis hur det låter fråga på.",
                Alias = "SuperKrikkan99",
                CreatedAt = DateTime.Now,
            },
            new()
            {
                TopicCategory = categories[3],
                Title = "Jack hade VISST fått plats på dörren i Titanic och jag har räknat på det",
                BodyText =
                    "okej jag såg Titanic igen igår och jag vägrar släppa de här.\n\nalla säger \"de handlar inte om plats de handlar om flytkraft\" OKEJ. så jag gjorde ett test.\n\njag ritade upp dörren ungefär efter storleken i filmen och räknade på hur Jack hade kunnat ligga. problemet är att han försöker klättra upp som en idiot och får hela skiten att tippa.\n\nhan ska INTE ligga bredvid Rose.\n\nRose flyttar sig typ 30 cm åt vänster. Jack lägger överkroppen diagonalt över dörren, ena benet utanför och använder sin flytväst under kanten för extra flytkraft.\n\nboom. två personer.\n\njag testade även detta hemma med en gammal garderobsdörr i badkaret men de gick sådär eftersom badkaret är 160cm och jag är 176cm. fick också vatten över hela golvet och min flickvän frågade vad fan jag höll på med.\n\nmen PRINCIPEN FUNGERAR.\n\nJames Cameron hade alltså kunnat rädda Jack men valde drama.\n\njag tänker inte diskutera detta mer.\n\nEDIT: sluta skriva att de inte var en dörr. de förändrar ingenting.",
                Alias = "TEAMJACK",
                CreatedAt = DateTime.Now,
            },
        };
        var topicResponses = new List<TopicResponse>
        {
            new()
            {
                TopicParent= topics[4],
                CommentBody="Bror, du gjorde alltså en Titanic-simulering i badkaret och när flickvännen konfronterade dig valde du ändå att stå fast vid vetenskapen :D\r\n\r\nMen jag respekterar ändå engagemanget. Cameron: ”Det handlar om flytkraft.”\r\nDu: ”Fel. Jag har en garderobsdörr och ett Excel-ark.”\r\n\r\nDet enda som saknas nu är att du bygger en fullskalig Titanic-modell på uppfarten för att bevisa det en gång för alla.\r\n\r\nOch ”jag tänker inte diskutera detta mer” efter att ha skrivit en hel vetenskaplig avhandling om Jack och en dörr är kanske det mest aggressiva jag läst idag.",
                ResponderAlias="CameronLover82",
                CreatedAt= DateTime.Now,
            },
             new()
            {
                TopicParent= topics[4],
                CommentBody="Jag behöver inte bygga en fullskalig modell. Jag har redan bevisat min tes.\r\n\r\nAtt experimentet slutade med vatten över hela badrumsgolvet och en flickvän som övervägde att lämna mig är irrelevant för den vetenskapliga processen.\r\n\r\nOch för övrigt: jag har identifierat ytterligare ett problem med Camerons version.\r\n\r\nJack hade kunnat ta av sig byxorna och använda dem som flythjälp.\r\n\r\nJag återkommer när jag har räknat på det.",
                ResponderAlias="TEAMJACK",
                CreatedAt= DateTime.Now,
            },
              new()
            {
                TopicParent= topics[3],
                CommentBody="Men vänta nu, hur gick det här ens till? :D Ni var kompisar från början och helt plötsligt blev personen din kusin? Jag behöver hela storyn, för det där känns som en sjuk familjeplot twist. Hur upptäckte ni det och vem av er fattade det först? :O",
                ResponderAlias="FionaPear",
                CreatedAt= DateTime.Now,
            },
               new()
            {
                TopicParent= topics[3],
                CommentBody="NEJ men det där låter som början på en hel dokumentär :) Hur kan man ens råka upptäcka att ens polare egentligen är släkt med en? Vem kom på det och hur lång tid tog det innan ni bara accepterade att ni nu är kusiner? :D",
                ResponderAlias="Wannaknowitall1",
                CreatedAt= DateTime.Now,
            },
                new()
            {
                TopicParent= topics[0],
                CommentBody="BROOOO :D:D:D \"lite mer el i jäveln\" JAG DÖR :O:O nästa gång du kör hela jävla avsmakningsmenyn eller?? först bilbatteri sen spolarvätska till efterrätt, SOMMELIER PÅ BILVERKSTAN :D",
                ResponderAlias="KrutTorr99",
                CreatedAt= DateTime.Now,
            },
                 new()
            {
                TopicParent= topics[0],
                CommentBody="HAHAHA jag respekterar ändå nischen :D:D:D alla andra sitter och snackar om chips och godis, här kommer ni och upptäcker en helt ny smakvärld :O \"sura nappar fast med lite mer el\" låter ju faktiskt som en jävligt stark recension, 10/10 kreativitet",
                ResponderAlias="FunGal4567",
                CreatedAt= DateTime.Now,
            },
        };
        if (!_context.Categories.Any())
        {
            _context.Categories.AddRange(categories);
        }

        if (!_context.Topics.Any())
        {
            _context.Topics.AddRange(topics);
        }
        _context.SaveChanges();
    }
}