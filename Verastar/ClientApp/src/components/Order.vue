<template>
    <h1 id="tableLabel">Complete Your Order</h1>

    <p>Just a few detail and your order will be on it's way.</p>

    <div class="order-form my-4 mx-4">
        <form v-on:submit.prevent="postOrder">
            <div class="container pt-4">

                <div class="row">
                    <div class="col-12">

                        <div class="row mx-4">
                            <div class="col-12 mb-2">
                                <label for="companyname" class="order-form-label">Company Name</label>
                            </div>
                            <div class="col-12 col-sm-12 mt-2 mt-sm-0">
                                <input id="companyname" name="companyname" v-model="order.companyname" class="order-form-input" placeholder="Company name">
                            </div>
                        </div>
                        <div class="row mx-4">
                            <div class="col-12 mb-2">
                                <label class="order-form-label">Name</label>
                            </div>
                            <div class="col-12 col-sm-6">
                                <input name="firstname" v-model="order.firstname" class="order-form-input" placeholder="First name">
                            </div>
                            <div class="col-12 col-sm-6 mt-2 mt-sm-0">
                                <input name="lastname" v-model="order.lastname" class="order-form-input" placeholder="Last">
                            </div>
                        </div>

                        <Address @address-updated="updateAddress"></Address>

                        <div class="row mt-3 mx-4">
                            <div class="col-12">
                                <div class="form-check">
                                    <input type="checkbox" v-model="order.agreeterms" class="form-check-input" name="validation" id="validation" value="1">
                                    <label for="validation" class="form-check-label">Agree to terms and conditions</label>
                                </div>
                            </div>
                        </div>

                        <div class="row mt-3">
                            <div class="col-12">
                                <button type="submit" id="btnSubmit" @onclick="postOrder()" class="btn btn-dark d-block mx-auto btn-submit">Submit</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </form>
    </div>

</template>

<script>
    import axios from 'axios'
    import Address from './Address.vue'

    export default {
        name: "MobilePhones",
        components: {
            Address
        },
        data() {
            return {
                order: {
                    companyname: "",
                    firstname: "",
                    lastname: "",
                    agreeterms: false,
                    address: {}
                },
                mobiles: []
            }
        },
        methods: {
            updateAddress(data) {
                this.order.address = data;
            },
            postOrder() {
                this.order.address = Address.address;

                axios.post('/Order', this.order)
                    .then((response) => {
                        if (response == "Ok")
                            console.log("Order complete");
                        else
                            console.log("Order failed");
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            }
        },
        mounted() {
        }
    }
</script>

<style>

    .order-form .container {
        color: #4c4c4c;
        padding: 20px;
        box-shadow: 0 0 10px 0 rgba(0, 0, 0, .1);
    }

    .order-form-label {
        margin: 8px 0 0 0;
        font-size: 14px;
        font-weight: bold;
    }

    .order-form-input {
        width: 100%;
        padding: 8px 8px;
        border-width: 1px !important;
        border-style: solid !important;
        border-radius: 3px !important;
        font-family: 'Open Sans', sans-serif;
        font-size: 14px;
        font-weight: normal;
        font-style: normal;
        line-height: 1.2em;
        background-color: transparent;
        border-color: #cccccc;
    }

    .btn-submit:hover {
        background-color: #090909 !important;
    }
</style>