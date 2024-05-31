package logica;

public class Domicilio extends Pedido implements ICobrar {

    private float preciodomicilio;
    private String direccion;

    public Domicilio(float preciodomicilio, String direccion) {
        this.preciodomicilio = preciodomicilio;
        this.direccion = direccion; 
    }
   

    public Domicilio() {

    }

    public float getPeso() {
        return preciodomicilio;
    }

    public void setPeso(float peso) {
        this.preciodomicilio = peso;
    }

    public float getPreciodomicilio() {
        return preciodomicilio;
    }

    public void setPreciodomicilio(float preciodomicilio) {
        this.preciodomicilio = preciodomicilio;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    @Override

    public float calcularCosto() {
        float total = (float) (calcularCostoTotal() + preciodomicilio);
        return total;
    }


    @Override
    public String toString() {
        return "Domicilio{" + "preciodomicilio=" + preciodomicilio + ", direccion=" + direccion + '}';
    }
    

}