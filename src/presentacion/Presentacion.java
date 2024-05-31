
package presentacion;

import java.util.InputMismatchException;
import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;
import logica.Pedido;
import logica.Cliente;
import logica.ExcepcionCantidadInvalida;
import logica.Comida;
import logica.Domicilio;
import logica.Reserva;
import logica.Restaurante;

public class Presentacion {

    public static void main(String[] args) {
     boolean bandera = false;
        List<Cliente> clientes = new LinkedList<>();
        List<Comida> productos = new LinkedList<>();

        int opcion1;
        int opcion2;
        Scanner entrada = new Scanner(System.in);
        List<Comida> platos = new LinkedList<>();
        Comida[] datosComida = {
            new Comida("Hamburguesa", 1, 30, 12000f),
            new Comida("Papas", 2, 100, 5000f),
            new Comida("Pizza", 3, 20, 5000f),
            new Comida("Perro Caliente", 4, 30, 12000f),
            new Comida("Sandwich", 5, 20, 12000f),
            new Comida("Gaseosa", 6, 100, 3000f)
        };
        Restaurante tienda = new Restaurante("Julianita", productos, clientes);
        tienda.setClientes(clientes);
        tienda.asignarCodigos();
        //MENU
        System.out.println("BIENVENIDO AL SISTEMA DE GESTIÓN DE COMPRAS");
        try {
            do {

                Menu0();
                opcion2 = entrada.nextInt();
                Espacio();
                entrada.nextLine();

                switch (opcion2) {

                    case 1:
                        System.out.print("Nombre del cliente: ");
                        String nombreCliente = entrada.nextLine();
                        if (Validar(nombreCliente)) {
                            Pedido pedido = new Pedido();
                            Cliente cliente = new Cliente(nombreCliente, pedido);
                            cliente.setNombre(nombreCliente);
                            clientes.add(cliente);
                            cliente.addCarrito(pedido);
                            tienda.setCliente(cliente);
                            System.out.println(cliente.getNombre());

                            String opcion;
                            do {
                                System.out.println(tienda.mostrarProductos());
                                System.out.println("Ingrese el código del producto para agregarlo al carrito: ");

                                int compra = entrada.nextInt();
                                entrada.nextLine();
                                if (compra >= 0 && compra < productos.size()) {

                                    for (Comida producto : pedido.getProductos()) {
                                        if (compra == producto.getCodigo()) {
                                            pedido.quitarProducto(producto);
                                            System.out.println("Este producto ya esta en tu carrito, se reasignará la cantidad a comprar");
                                        }
                                    }
                                    int cantidades;
                                    do {
                                        System.out.println("Ingrese la cantidad deseada: ");
                                        try {
                                            cantidades = entrada.nextInt();
                                            entrada.nextLine();

                                            if (cantidades > 0) {
                                                productos.get(compra).setCantidadVendida(cantidades);
                                                System.out.println("Se han añadido: " + cantidades + " unidades de " + productos.get(compra).getNombre() + " a su carrito \n");
                                                break;
                                            }
                                        } catch (InputMismatchException e) {
                                            System.out.println("Error al vender: " + e.getMessage());
                                            entrada.nextLine();
                                        }
                                        System.out.println("Por favor ingrese una cantidad válida");
                                    } while (!bandera);

                                    Comida productoSeleccionado = productos.get(compra);
                                    pedido.añadirProducto(productoSeleccionado);
                                    System.out.println("Producto agregado al carrito");
                                } else {
                                    System.out.println("El código no existe. Intente nuevamente.");
                                }

                                System.out.println("¿Desea agregar otro producto? s/n \n");
                                opcion = entrada.nextLine();
                            } while (!opcion.equalsIgnoreCase("n"));
                            do {
                                Menu1();
                                opcion1 = entrada.nextInt();
                                Espacio();
                                entrada.nextLine();
                                switch (opcion1) {
                                    case 1:
                                        System.out.println(pedido.mostrarCarrito());

                                        break;

                                    case 2:
                                        if (!cliente.getProductosComprados().isEmpty()) {
                                            System.out.println("No es posible eliminar productos, ya se ha realizado la compra");
                                        } else if (!cliente.getCarrito().getProductos().isEmpty()) {
                                            System.out.println("\n----- Su Carrito -----");
                                            System.out.println(pedido.mostrarCarrito());
                                            System.out.println("---------------------------------");
                                            try {
                                                System.out.println("Ingrese el código del producto a eliminar: ");
                                                int codigoEliminar = entrada.nextInt();
                                                entrada.nextLine();

                                                if (codigoEliminar >= 0 && codigoEliminar < productos.size()) {
                                                    System.out.println("Ingrese la cantidad a eliminar: ");
                                                    int cantidadEliminar = entrada.nextInt();
                                                    entrada.nextLine();

                                                    try {
                                                        pedido.quitarProducto(codigoEliminar, cantidadEliminar);

                                                        if (!pedido.getProductos().isEmpty()) {
                                                            boolean encontrado = false;

                                                            for (int i = 0; i < pedido.getProductos().size(); i++) {
                                                                if (pedido.getProductos().get(i).getCodigo() == codigoEliminar) {
                                                                    System.out.println("El producto se ha reducido a " + pedido.getProductos().get(i).getCantidadVendida());
                                                                    encontrado = true;
                                                                    break;
                                                                }
                                                            }

                                                            if (!encontrado) {
                                                                System.out.println("El producto se ha eliminado del carrito");
                                                            }
                                                        } else {
                                                            System.out.println("El carrito ha quedado vacío");
                                                        }
                                                    } catch (ExcepcionCantidadInvalida e) {
                                                        System.out.println("Error al eliminar el producto: " + e.getMessage());
                                                    }
                                                } else {
                                                    System.out.println("El código ingresado no es válido");
                                                }
                                            } catch (InputMismatchException e) {
                                                System.out.println("Error al ingresar el código o la cantidad. Por favor, ingrese valores numéricos.");
                                                entrada.nextLine(); // Limpiar el buffer del teclado en caso de error
                                            }
                                        } else {
                                            System.out.println("Su carrito está vacio");
                                        }
                                        Espacio();

                                        break;
                                    case 3:
                                        if (!cliente.getCarrito().getProductos().isEmpty()) {
                                            if (cliente.getProductosComprados().isEmpty()) {
                                                System.out.println("Compra realizada:");
                                                tienda.realizarCompra();
                                                System.out.println(pedido.mostrarCarrito());
                                                System.out.println("Total: " + pedido.calcularCostoTotal());
                                            } else {
                                                System.out.println("Ya se ha realizado la compra!");
                                            }
                                        } else {
                                            System.out.println("Su carrito está vacio");
                                        }
                                        break;

                                    case 4:
                                        if (cliente.getProductosComprados().isEmpty()) {
                                            System.out.println("El cliente se ha resgitrado sin compras");
                                        } else {
                                            System.out.println("Gracias por su compra!");
                                        }
                                        break;

                                    default:
                                        throw new AssertionError("Digita una opcion válida");
                                }

                            } while (opcion1 != 4);
                        }
                        break;

                    case 2:
                        if (!clientes.isEmpty()) {
                            System.out.println(tienda.mostrarClientes());

                        } else {
                            System.out.println("No hay clientes registrados.");
                        }
                        break;

                    case 3:
                        System.out.println("Hasta Luego");
                        break;
                    default:
                        System.out.println("Opcion inválida");

                }
            } while (opcion2 != 3);
        } catch (InputMismatchException e) {
            System.out.println("Error: Debes ingresar un número. Inténtalo de nuevo.");
        }

    }

    public static void Espacio() {
        for (int i = 0; i < 8; i++) {
            System.out.println();
        }
    }

    public static void Menu0() {
        System.out.println("-------------------------------------");
        System.out.println("1. Registrar compra. ");
        System.out.println("2. Consultar informacion clientes");
        System.out.println("3. Salir");
        System.out.println("-------------------------------------");
        System.out.print("Digite una opcion: ");
    }

    public static void Menu1() {
        System.out.println("1.Mostrar Carrito");
        System.out.println("2.Eliminar Producto");
        System.out.println("3.Pagar Compra");
        System.out.println("4. Efectuar y salir");
        System.out.println("-------------------------------------");
        System.out.print("Digite una opcion: ");
    }

    public static boolean Validar(String nombre) {
        Scanner scanner = new Scanner(System.in);
        do {
            try {
                if (nombre == null || nombre.isEmpty()) {
                    throw new IllegalArgumentException("El nombre del cliente no puede ser nulo o vacío.");
                }

            } catch (IllegalArgumentException e) {
                System.out.println("Error al crear el cliente: " + e.getMessage());
                System.out.print("Ingrese un nombre válido: ");
                nombre = scanner.nextLine();
            }
        } while (nombre == null || nombre.isEmpty());
        System.out.println("Cliente registrado con éxito!");

        return true;

    }

}


