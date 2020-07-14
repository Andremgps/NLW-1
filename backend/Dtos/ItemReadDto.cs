namespace backend.Dtos
{
  public class ItemReadDto
  {
    public int Id { get; set; }
    public string Title { get; set; }

    //Propriedade imagem tem que existir mas não precisa ser retornada na api
    public string Image;
    public string Image_Url
    {
      get { return $"http://192.168.2.101/Uploads/{Image}"; }
    }
  }
}