<template>
    <div>
        <!-- Start Page Title Area -->
        <div class="page-title-area">
            <div class="container">
                <ul>
                    <li><nuxt-link to="/">Home</nuxt-link></li>
                    <li>Carrinho</li>
                </ul>
            </div>
        </div>
        <!-- End Page Title Area -->

        <!-- Start Checkout Area -->
		<section class="checkout-area ptb-60">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12">
                        <div class="user-actions">
                            <i class="fas fa-sign-in-alt"></i>
                            <span>Já possui cadastro? <nuxt-link to="/login">Clique aqui para logar</nuxt-link></span>
                        </div>
                    </div>
                </div>

                <form>
                    <div class="row">
                        <div class="col-lg-6 col-md-12">
                            <div class="billing-details">
                                <h3 class="title">Detalhes de cobrança</h3>

                                <div class="row">
                                    <div class="col-lg-12 col-md-6">
                                        <div class="form-group">
                                            <label>Nome completo <span class="required">*</span></label>
                                            <input type="text" id="fullName" v-model="personDetails.fullName" class="form-control">
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-6">
                                        <div class="form-group">
                                            <label>Endereço <span class="required">*</span></label>
                                            <input type="text" id="address" v-model="personDetails.address" class="form-control">
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-6">
                                        <div class="form-group">
                                            <label>Cidade <span class="required">*</span></label>
                                            <input type="text" id="city" v-model="personDetails.city" class="form-control">
                                        </div>
                                    </div>

                                    <div class="col-lg-6 col-md-6">
                                        <div class="form-group">
                                            <label>Endereço de e-mail <span class="required">*</span></label>
                                            <input type="email" id="email" v-model="personDetails.email" class="form-control">
                                        </div>
                                    </div>

                                    <div class="col-lg-6 col-md-6">
                                        <div class="form-group">
                                            <label>Telefone <span class="required">*</span></label>
                                            <input type="text" id="phone" v-model="personDetails.phone" class="form-control">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 col-md-12">
                            <div class="order-details">
                                <h3 class="title">Seu pedido</h3>

                                <div class="order-table table-responsive">
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th scope="col">Nome do Produto</th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>

                                        <tbody>

                                            <tr v-for="(cart, i) in cart" :key="i">
                                                <td class="product-name">
                                                    <a href="#">{{cart.name}}</a>
                                                </td>

                                                <td class="product-total">
                                                    <span class="subtotal-amount">R$ {{cart.price * cart.quantity}}</span>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="order-subtotal">
                                                    <span>Subtotal do Carrinho</span>
                                                </td>

                                                <td class="order-subtotal-price">
                                                    <span class="order-subtotal-amount">R$ {{cartTotal}}</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="order-shipping">
                                                    <span>Frete</span>
                                                </td>

                                                <td class="shipping-price">
                                                    <span>R$ 10.00</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="total-price">
                                                    <span>Total</span>
                                                </td>

                                                <td class="product-subtotal">
                                                    <span class="subtotal-amount">R$ {{parseFloat(cartTotal + 10).toFixed(2)}}</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>

                                <div class="payment-method">
                                    <p>
                                        <input type="radio" id="direct-bank-transfer" name="radio-group" checked>
                                        <label for="direct-bank-transfer">Transferência Bancária</label>
                                        Faça o seu pagamento diretamente em nossa conta bancária. Use seu ID do pedido como referência de pagamento. Seu pedido não será enviado até que os fundos sejam liberados em nossa conta.
                                    </p>
                                    <p>
                                        <input type="radio" id="paypal" name="radio-group">
                                        <label for="paypal">PayPal</label>
                                    </p>
                                    <!-- <p>
                                        <input type="radio" id="cash-on-delivery" name="radio-group">
                                        <label for="cash-on-delivery">Cash on Delivery</label>
                                    </p> -->
                                </div>

                                <a href="javascript:void(0)" @click="add" class="btn btn-primary order-btn">Fazer pedido</a>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </section>
		<!-- End Checkout Area -->
    </div>
</template>

<script>

export default {
    data(){
        return{
            personDetails: {
                fullName: 'John Doe', 
                address: 'Town hall, av 02',
                city: 'New York',
                email: 'john@gmail.com',
                phone: '+990198378372',
                createdAt: new Date()
            }
        }
    },
    computed: {
        cart(){
            return this.$store.getters.cart
        },
        cartTotal(){
            return this.$store.getters.totalAmount
        }
    }, 
    methods: {
        add(){
            // const cartData = {
            //     details: this.personDetails,
            //     items: this.cart
            // }
            // const db = firebase.firestore();
            // const dbOrderRef = db.collection('orders');
            // dbOrderRef.add(cartData);
            // this.$toast.success(`Thanks for the order`, {
            //     icon: 'fas fa-cart-plus'
            // });
            // this.$store.dispatch('cartEmpty')
            // this.$router.push("/");
        }
    }
}
</script>