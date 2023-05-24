//usar uapi y modelos 
using EmpresaUTN.UAPI;
using EmpresaUTN.Modelos;

/*

//crud de Restaurante
var uapi = new Crud<Restaurante>();


//var ec = uapi.SelectById("https://localhost:7006/api/Restaurantes", "1");
//ec.Direccion = "Alejandro Andrade 1030 y General Enriquez";
// uapi.Update("https://localhost:7006/api/Restaurantes", "1", ec);



/*
var re= new Restaurante
{
Nombre = "El pollo loco",
Direccion = "Alejandro Andrade 1030 y General Enriquez",
Telefono = "0987654321",
Especialidad = "Pollo a la brasa",
CodigoRestaurante= 2
};
var nuevoPais = uapi.Insert("https://localhost:7006/api/Restaurantes", re);

*/
/*

//eliminar pais
 uapi.Delete("https://localhost:7006/api/Restaurantes", "2");


var restaurantes = uapi.Select("https://localhost:7006/api/Restaurantes");


*/


/*
//crud plato
var platos = new Crud<Plato>();
var nuevoPlato = platos.Insert("https://localhost:7006/api/Platos", new Plato
{
    Nombre = "Pizza Moka",
    Descripcion = "Especialidad de la casa",
    Precio = 7.00,
    Categoria = "Pizza",
    Id = 0
    
});
*/


Console.WriteLine("Listado de restaurantes"); 
