<template>
    <div>
        <router-link :to="{name: 'home'}">Home Page</router-link>
         <form @submit.prevent="createVault()">
            <input type="text" v-model="newVault.name" placeholder="name">
            <input type="text" v-model="newVault.description" placeholder="description">
            <button class="btn btn-primary" type="submit">Create New Vault</button>
        </form>
        <div class="card" style="width: 18rem;" v-for="vault in vaults" :key="vault.id">
        <div class="card-body">
            <h5 class="card-title">{{vault.name}}</h5>
            <p class="card-text">{{vault.description}}</p>
            <button class="btn btn-danger" @click="deleteVault(vault.id)">delete me</button>
        </div>
        </div>

    </div>
</template>

<script>
    import userVault from '@/components/userVault.vue'
export default {
    name: 'Vaults', 
    mounted() {
        this.$store.dispatch("getUserVaults")
        //get all vaults
    },
    data(){
        return {
            newVault: {
                name: "", 
                description: ""
            }
        }
    }, 
    computed: {
        user() {
            return this.$store.state.user

        }, 
        vaults(){
            return this.$store.state.vaults
        }
    }, 
    components: {
        userVault 
    }, 
    methods: {
        createVault() {
            this.$store.dispatch("createVault", this.newVault)
        }, 
        deleteVault(id) {
            this.$store.dispatch("deleteVault", id)
        }
    }
}
</script>

<style>

</style>
