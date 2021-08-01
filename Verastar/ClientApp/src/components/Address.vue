<template>
    <div class="row mt-3 mx-4">
        <div class="col-12">
            <label class="order-form-label">Address</label>
        </div>
        <div class="col-12">
            <input id="autoaddress" class="order-form-input" autocomplete="off" placeholder="Start typing the first line of your address here" />
        </div>
        <div class="col-12 mt-2">
            <input v-model="address.line1" class="order-form-input" placeholder="Street Address" @change="updateAddress" />
        </div>
        <div class="col-12 mt-2">
            <input v-model="address.line2" class="order-form-input" placeholder="Second line" @change="updateAddress" />
        </div>
        <div class="col-12 col-sm-6 mt-2 pr-sm-2">
            <input v-model="address.towncity" class="order-form-input" placeholder="City" @change="updateAddress" />
        </div>
        <div class="col-12 col-sm-6 mt-2 pl-sm-0">
            <input v-model="address.district" class="order-form-input" placeholder="Region" @change="updateAddress" />
        </div>
        <div class="col-12 col-sm-6 mt-2 pr-sm-2">
            <input v-model="address.postcode" class="order-form-input" placeholder="Postal / Zip Code" @change="updateAddress" />
        </div>
    </div>
</template>


<script>

    import axios from 'axios'
    import autocomplete from "autocompleter";

    export default {
        name: "Address",
        data() {
            return {
                addresses: [],
                address: {
                    postcode: "",
                    line1: "",
                    line2: "",
                    towncity: "",
                    district: ""
                }
            }
        },
        methods: {
            updateAddress() {
                this.$emit('address-updated', this.address);
            }
        },
        mounted() {

            var vm = this;
            autocomplete({
                minLength: 1,
                input: document.querySelector("#autoaddress"),
                fetch: function (text, update) {
                    if (text.length < 3)
                        return;
                    text = text.toLowerCase();
                    axios.get('/Address/ByTerm?term=' + text)
                        .then((response) => {
                            vm.addresses = response.data.suggestions;
                        })
                        .catch(function (error) {
                            console.log(error);
                        });
                    var suggestions = vm.addresses;

                    
                    update(suggestions);
                },
                render: function (item) {
                    var div = document.createElement("div");
                    div.textContent = item.address;
                    return div;
                },
                onSelect: function (item) {

                    axios.get('/Address/ById?id=' + item.id)
                        .then((response) => {
                            vm.address = response.data;
                            document.querySelector("#autoaddress").value = "";
                        })
                        .catch(function (error) {
                            console.log(error);
                        });
                }
            });
        },

    }
</script>

<style>

    .autocomplete {
        background: white;
        z-index: 1000;
        font: 14px/22px "-apple-system", BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
        overflow: auto;
        box-sizing: border-box;
        border: 1px solid rgba(50, 50, 50, 0.6);
    }

    .autocomplete * {
        font: inherit;
    }

    .autocomplete > div {
        padding: 0 4px;
    }

    .autocomplete .group {
        background: #eee;
    }

    .autocomplete > div:hover:not(.group),
    .autocomplete > div.selected {
        background: #81ca91;
        cursor: pointer;
    }

</style>