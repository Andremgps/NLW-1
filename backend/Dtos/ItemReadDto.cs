namespace backend.Dtos
{
    public class ItemReadDto
    {                                 
        public string Title { get; set; }   

        //Propriedade imagem tem que existir mas não precisa ser retornada na api
        public string Image;     
        public string Image_Url
        {
            get { return $"https://localhost:5001/Uploads/{Image}"; }
        }
    }
}