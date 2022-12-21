using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieInfo.InternalApi.Migrations
{
    public partial class AddDefaultDataForTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into ""Actor""(""Id"", ""Name"", ""Rating"", ""Score"", ""ConcurrencyToken"")
                values ('9289502e-0843-45dc-b60b-94f1005ecc62', 'Ewan McGregor', '0', '0.0', 'e52c7a90-b521-4217-9f53-2a14aa5a01db'),
                        ('83158cd1-ece8-43b2-838a-b1fe2bcd0c63', 'Johnny Depp', '0', '0.0', '1b6eda1b-3855-475f-ba31-b8dbba91f6f6'),
                        ('c439fdd5-5056-41ed-9c32-5accf0cdd639', 'Helena Bonham Carter', '0', '0.0', '3add55c0-91d3-4eb1-aefa-bdf20cbec2b0'),
                        ('74ef0642-299d-4fa0-b5f1-bf171942eb43', 'Orlando Bloom', '0', '0.0', '7077841b-9abc-44bc-b7b0-e96471584fd2');
            ");

            migrationBuilder.Sql(@"
                insert into ""Movie""(""Id"", ""Title"", ""Rating"", ""Score"", ""Description"", ""RealeseDate"", ""ConcurrencyToken"")
                values ('0741bb58-6bce-4bf1-a7f2-01c6757ca174', 'Крупная рыба', '0', '0.0', 'В основу этой приключенческой ленты положен роман Дэниела Уоллеса «Большая рыба: роман мифических пропорций»...', '2003-12-04', 'abca04d7-2c53-43e7-8d05-c81afa765c0f'),
                        ('4564ed72-d597-40eb-b8b6-a04f88aeba65', 'Чарли и шоколадная фабрика', '0', '0.0', 'Какие чудеса ждут вас на фабрике Вилли Вонки? Только представьте: травяные луга из сладкого мятного сахара в Шоколадной Комнате...', '2005-07-10', '0b8e1a24-d2dc-4430-b0ec-f0338ed80885'),
                        ('3cd33ab9-6830-4a1d-877b-b24550a25bcb', 'Мрачные тени', '0', '0.0', 'Барнабас Коллинз, владелец поместья Коллинвуд, богат, властен и слывет неисправимым Казановой, пока не совершает роковую ошибку, разбив сердце Анжелики Бошар...', '2012-05-09', '734879ac-50bd-4426-81db-07aed0cc3aeb'),
                        ('4f4d2caa-d45f-48b6-835e-fb7baf7d187d', 'Мордекай', '0', '0.0', 'В центре сюжета – история Чарльза Мордекая, обходительного арт-дельца и жулика по совместительству, который путешествует по всему миру и с помощью своего неотразимого обаяния пытается раздобыть украденную картину...', '2015-01-09', '9c066de6-6cb0-4dfb-8b52-4007afd420df');
            ");

            migrationBuilder.Sql(@"
                insert into ""MovieActor""(""MovieId"", ""ActorId"")
                values ('4f4d2caa-d45f-48b6-835e-fb7baf7d187d', '9289502e-0843-45dc-b60b-94f1005ecc62'),
                        ('0741bb58-6bce-4bf1-a7f2-01c6757ca174', '9289502e-0843-45dc-b60b-94f1005ecc62'),
                        ('0741bb58-6bce-4bf1-a7f2-01c6757ca174', 'c439fdd5-5056-41ed-9c32-5accf0cdd639'),
                        ('4564ed72-d597-40eb-b8b6-a04f88aeba65', '83158cd1-ece8-43b2-838a-b1fe2bcd0c63'),
                        ('3cd33ab9-6830-4a1d-877b-b24550a25bcb', '83158cd1-ece8-43b2-838a-b1fe2bcd0c63'),
                        ('4f4d2caa-d45f-48b6-835e-fb7baf7d187d', '83158cd1-ece8-43b2-838a-b1fe2bcd0c63'),
                        ('4564ed72-d597-40eb-b8b6-a04f88aeba65', 'c439fdd5-5056-41ed-9c32-5accf0cdd639'),
                        ('3cd33ab9-6830-4a1d-877b-b24550a25bcb', 'c439fdd5-5056-41ed-9c32-5accf0cdd639');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
