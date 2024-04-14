using System;
using System.Collections.Generic;

namespace GeneradorDatosPrueba
{
    public class Generador
    {
        private static readonly Random random = new Random();

        private static readonly List<string> nombresRusos = new List<string>
        {
            "Александр", "Михаил", "Иван", "Дмитрий", "Андрей", "Сергей", "Максим", "Артем", "Николай", "Алексей", "Денис", "Евгений", "Владимир", "Илья", "Павел", "Кирилл", "Александр", "Роман", "Егор", "Тимофей", "Даниил", "Олег", "Владислав", "Игорь", "Станислав", "Глеб", "Арсений", "Антон", "Виктор", "Федор", "Виталий", "Марк", "Василий", "Георгий", "Матвей", "Данила", "Вадим", "Семен", "Тимур", "Богдан", "Давид", "Макар", "Леонид", "Руслан", "Марат", "Михаил", "Ярослав", "Валентин", "Савелий", "Дмитрий", "Святослав", "Евгений", "Вячеслав", "Илья", "Валентин", "Алексей", "Михаил", "Никита", "Сергей", "Дмитрий", "Андрей", "Семен", "Артем", "Степан", "Денис", "Павел", "Григорий", "Роман", "Тимур", "Владислав", "Игорь", "Владимир", "Кирилл", "Дмитрий", "Николай", "Анатолий", "Филипп", "Сергей", "Артем", "Виталий", "Олег", "Михаил", "Александр", "Даниил", "Егор", "Иван", "Владимир", "Андрей", "Илья", "Валентин", "Константин", "Семен", "Петр", "Максим", "Давид", "Тимофей", "Станислав", "Алексей", "Борис"
        };

        private static readonly List<string> nombresEspanol = new List<string>
        {
            "Sofía", "Lucía", "Martina", "María", "Paula", "Julia", "Emma", "Valeria", "Daniela", "Alba", "Carla", "Sara", "Claudia", "Valentina", "Alma", "Ana", "Inés", "Carmen", "Laia", "Elena", "Luna", "Emma", "Adriana", "Aitana", "Vega", "Olivia", "Ainhoa", "Victoria", "Isabella", "Eva", "Marta", "Nora", "Ariadna", "Noa", "Leire", "Celia", "Julia", "Natalia", "Rocio", "Amaia", "Aina", "Irene", "Jimena", "Alicia", "Lola", "Carolina", "Iris", "Mireia", "Marina", "Laura", "Valeria", "Candela", "Ana", "Clara", "Celia", "Júlia", "Gala", "Iria", "Abril", "Leyre", "Naiara", "Elsa", "Blanca", "Irati", "Maia", "Zoe", "Lía", "Naia", "Elena", "Manuela", "Ayla", "Noelia", "Aroa", "Carla", "Gabriela", "Zaira", "Laia", "Lucía", "Ariadna", "Sara", "Yara", "Marta", "Diana", "Lara", "Mía", "Inés", "Ane", "Nerea", "Vera", "Olga"
        };

        private static readonly List<string> nombresChino = new List<string>
        {
            "Wang", "Li", "Zhang", "Liu", "Chen", "Yang", "Huang", "Wu", "Zhao", "Zhou", "Xu", "Sun", "Ma", "Zhu", "Hu", "Guo", "He", "Gao", "Lin", "Luo", "Zheng", "Liang", "Xie", "Song", "Tang", "Xu", "Han", "Feng", "Deng", "Cao", "Peng", "Zeng", "Xiao", "Tian", "Dong", "Yuan", "Pan", "Yu", "Jiang", "Cai", "Yu", "Du", "Ye", "Cheng", "Su", "Wei", "Lu", "Ding", "Ren", "Shen", "Yao", "Lu", "Jiang", "Cui", "Zhong", "Tan", "Lu", "Wang", "Fan", "Jin", "Shi", "Liao", "Jia", "Xia", "Wei", "Fu", "Fang", "Bai", "Zou", "Meng", "Xiong", "Qin", "Qiu", "Jiang", "Yin", "Xue", "Yan", "Duan", "Lei", "Li", "Shi", "Long", "Tao", "He", "Gu", "Mao", "Hao", "Gong", "Shao", "Wan"
        };

        private static readonly List<string> nombresFrances = new List<string>
        {
            "Léa", "Manon", "Chloé", "Emma", "Inès", "Jade", "Camille", "Sarah", "Louise", "Clara", "Lucas", "Louis", "Enzo", "Gabriel", "Arthur", "Raphaël", "Adam", "Hugo", "Jules", "Maël", "Léo", "Nathan", "Tom", "Noah", "Mathis", "Liam", "Ethan", "Sacha", "Paul", "Timéo", "Anaïs", "Alice", "Lina", "Eva", "Manon", "Julie", "Lisa", "Léna", "Zoé", "Lola", "Laura", "Charlotte", "Juliette", "Romane", "Mélissa", "Elise", "Éléna", "Éva", "Océane", "Louna", "Antoine", "Théo", "Lucas", "Tom", "Louis", "Mathis", "Hugo", "Nathan", "Raphaël", "Noah", "Ethan", "Léo", "Sacha", "Enzo", "Adam", "Maël", "Paul", "Jules", "Gabriel", "Liam", "Léa", "Chloé", "Manon", "Emma", "Inès", "Jade", "Louise", "Sarah", "Camille", "Clara", "Lucas", "Louis", "Gabriel", "Enzo", "Arthur", "Raphaël", "Tom", "Léo", "Hugo", "Jules", "Adam", "Maël", "Nathan", "Liam", "Sacha", "Paul", "Noah", "Théo", "Mathis", "Timéo"
        };

        private static readonly List<string> apellidosRuso = new List<string>
        {
            "Смирнов", "Іванов", "Кузнєцов", "Попов", "Васильєв", "Петров", "Соколов", "Михайлов", "Новиков", "Федоров", "Морозов", "Волков", "Алексєєв", "Лєбєдь", "Семєнов", "Егоров", "Павлов", "Козлов", "Стєпанов", "Ніколаєв", "Орлов", "Андрєєв", "Макаров", "Нікітін", "Захаров", "Зайцев", "Соловйов", "Бєлов", "Медведєв", "Яковлєв", "Галкін", "Романов", "Воробйов", "Кошелєв", "Сєргєєв", "Павлюченко", "Сорокін", "Дмитрієв", "Григорьєв", "Ткач", "Костюк", "Королєв", "Гусєв", "Титов", "Кузьмін", "Кудрявцєв", "Баранов", "Кулик", "Артемов", "Щербак", "Панов", "Беляєв", "Комаров", "Денисов", "Казаков", "Фролов", "Жуков", "Горбачов", "Фомін", "Дорофєєв", "Бєліков", "Бєлоусов", "Потапов", "Лихачов", "Тимофєєв", "Федосєєв", "Шишкін", "Шевченко", "Родін", "Єрмаков", "Дмитрієв", "Данилов", "Козак", "Михайлов", "Герасимов", "Мартинов", "Єршов", "Горшков", "Сидоров", "Рязанов", "Ємельянов", "Рябов", "Анісімов", "Кузьмін", "Корнєєв", "Ефімов", "Дьячков", "Кулаков", "Лаптєв", "Шилов", "Бородін", "Закіров", "Давидов", "Голубєв", "Антонов", "Тарасов", "Бєров", "Полєв", "Марков", "Ісаєв", "Потьомкін", "Самсонов", "Князєв", "Бєсєдін"
        };

        private static readonly List<string> apellidosEspanol = new List<string>
        {
            "García", "Fernández", "González", "Rodríguez", "López", "Martínez", "Sánchez", "Pérez", "Gómez", "Martín", "Jiménez", "Ruiz", "Hernández", "Díaz", "Moreno", "Muñoz", "Alonso", "Gutiérrez", "Romero", "Navarro", "Torres", "Domínguez", "Vargas", "Gil", "Ramos", "Serrano", "Blanco", "Molina", "Morales", "Suárez", "Ortega", "Delgado", "Castro", "Ortiz", "Rubio", "Marín", "Sanz", "Iglesias", "Medina", "Garrido", "Cortés", "Castillo", "Santos", "Lozano", "Guerrero", "Cano", "Prieto", "Méndez", "Cruz", "Gallego", "Vidal", "León", "Herrera", "Peña", "Flores", "Cabrera", "Campos", "Vega", "Fuentes", "Carrasco", "Diez", "Caballero", "Reyes", "Nieto", "Aguilar", "Pascual", "Santana", "Herrero", "Lorenzo", "Montero", "Hidalgo", "Giménez", "Ibáñez", "Ferrer", "Duran", "Santiago", "Vicente", "Benítez", "Mora", "Arias", "Vargas", "Carmona", "Crespo", "Román", "Pastor", "Soto", "Sáez", "Velasco", "Moya", "Soler", "Parra", "Esteban", "Bravo", "Gallardo", "Rojas"
        };

        private static readonly List<string> apellidosChino = new List<string>
        {
            "Li", "Wang", "Zhang", "Liu", "Chen", "Yang", "Huang", "Zhao", "Wu", "Zhou", "Xu", "Sun", "Ma", "Zhu", "Hu", "Guo", "He", "Lin", "Gao", "Luo", "Zheng", "Song", "Han", "Tang", "Feng", "Yu", "Dong", "Xiao", "Cheng", "Cao", "Yuan", "Deng", "Wei", "Jiang", "Fu", "Bian", "Xie", "Shen", "Ye", "Xu", "Zeng", "Cai", "Peng", "Chang", "Pan", "Qi", "Lu", "Xiang", "Cui", "Wang", "Pei", "Fan", "Hong", "Zou", "Li", "He", "Liu", "Wei", "Jing", "Jian", "Hui", "Shi", "Yan", "Jia", "Tian", "Jiang", "Qi", "Shao", "Yi", "Xuan", "Du", "Bao", "Min", "Lou", "Kuang", "Piao", "Lei", "Geng", "Lu", "Ci", "Bai", "Chen", "Qian", "Yue", "Yin", "Ning", "Kan", "Lan", "Lin", "Yan", "Xiong", "Za", "Shi", "Ru", "Gong", "Meng", "Ao", "Pi", "Xie", "Zha"
        };

        private static readonly List<string> apellidosFrances = new List<string>
        {
            "Martin", "Bernard", "Dubois", "Thomas", "Robert", "Richard", "Petit", "Durand", "Leroy", "Moreau", "Simon", "Laurent", "Lefebvre", "Michel", "Garcia", "David", "Bertrand", "Roux", "Vincent", "Fournier", "Morel", "Girard", "Andre", "Lefevre", "Mercier", "Dupont", "Lambert", "Bonnet", "Francois", "Martinez", "Legrand", "Garnier", "Faure", "Rousseau", "Blanc", "Guerin", "Muller", "Henry", "Roussel", "Nicolas", "Perrin", "Morin", "Mathieu", "Clement", "Gauthier", "Dumont", "Lopez", "Fontaine", "Chevalier", "Robin", "Masson", "Sanchez", "Gerard", "Nguyen", "Boyer", "Denis", "Lemaire", "Duval", "Joly", "Gautier", "Roger", "Roche", "Roy", "Noel", "Meyer", "Lucas", "Meunier", "Jean", "Pierre", "Colin", "Hubert", "Renard", "Marchand", "Rey", "Perez", "Leclerc", "Guillaume", "Lacroix", "Brun", "Picard", "Poirier", "Gaillard", "Barbier", "Rolland", "Benoit", "Schmitt", "Vidal", "Leclercq", "Paris", "Maillard", "Jacquet", "Vasseur", "Legros", "Barreau", "Chapuis", "Berger"
        };

        public static List<string> Generar(int noRegistros, int ap1, int ap2, int name)
        {
            List<string> alumnos = new List<string>();

            for (int i = 0; i < noRegistros; i++)
            {
                string apellido = ObtenerApellido(ap1);
                string apellido2 = ObtenerApellido(ap2);
                string nombre = ObtenerNombre(name);

                int expediente = 222220000 + i;

                string alumno = expediente + ", ";
                alumno += apellido + ", ";
                alumno += apellido2 + ", ";
                alumno += nombre + ", ";
                alumno += "a" + expediente + "@correo.com" + ", ";

                DateTime fechaNacimiento = new DateTime(1980 + random.Next(40), random.Next(1, 13), random.Next(1, 29));
                alumno += fechaNacimiento.ToString("yyyy-MM-dd");

                alumnos.Add(alumno);
            }

            return alumnos;
        }

        private static string ObtenerApellido(int idIdioma)
        {
            switch (idIdioma)
            {
                case 1:
                    return apellidosRuso[random.Next(apellidosRuso.Count)];
                case 2:
                    return apellidosEspanol[random.Next(apellidosEspanol.Count)];
                case 3:
                    return apellidosChino[random.Next(apellidosChino.Count)];
                case 4:
                    return apellidosFrances[random.Next(apellidosFrances.Count)];
                default:
                    throw new ArgumentOutOfRangeException(nameof(idIdioma), "Idioma no reconocido");
            }
        }

        private static string ObtenerNombre(int idIdioma)
        {
            switch (idIdioma)
            {
                case 1:
                    return nombresRusos[random.Next(nombresRusos.Count)];
                case 2:
                    return nombresEspanol[random.Next(nombresEspanol.Count)];
                case 3:
                    return nombresChino[random.Next(nombresChino.Count)];
                case 4:
                    return nombresFrances[random.Next(nombresFrances.Count)];
                default:
                    throw new ArgumentOutOfRangeException(nameof(idIdioma), "Idioma no reconocido");
            }
        }
    }

}
