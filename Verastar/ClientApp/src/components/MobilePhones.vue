<template>
    <h1 id="tableLabel">Mobile Phones</h1>

    <p>Select one of our latest mobile phones available to order today.</p>

    <p v-if="!mobiles"><em>Loading...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" v-if="mobiles">
        <thead>
            <tr>
                <th>Name</th>
                <th>Manufacture</th>
                <th>Image</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="mobile of mobiles" v-bind:key="mobile">
                <td>{{ mobile.name }}</td>
                <td>{{ mobile.manufacture }}</td>
                <td><img v-bind:src="mobile.imagePath" /></td>
                <td>
                    <router-link :to="{ name: 'Order', query: { mobileid: mobile.id }}" class="btn">Order Now</router-link>
                </td>
            </tr>
        </tbody>
    </table>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "MobilePhones",
        data() {
            return {
                mobiles: []
            }
        },
        methods: {
            getMobilePhones() {
                axios.get('/MobilePhone')
                    .then((response) => {
                        this.mobiles =  response.data;
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            }
        },
        mounted() {
            this.getMobilePhones();
        }
    }
</script>