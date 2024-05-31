
package logica;


public class Reserva  extends Pedido implements ICobrar {
    private float precioextra;
    
        public Reserva(float precioextra) {
            this.precioextra = precioextra;
        }
      
    
        public float getImpuesto() {
            return precioextra;
        }
    
        public void setImpuesto(float impuesto) {
            this.precioextra = impuesto;
        }
       
        @Override
        public float calcularCosto(){
            float total;
            total = (float) (calcularCostoTotal()) + precioextra ;
            return total;
        }
    
        @Override
        public String toString() {
            return super.toString() + " impuesto: " + precioextra;
        }
       
       
    }